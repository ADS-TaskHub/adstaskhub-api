using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;
        private readonly IUserMapper _userMapper;
        private readonly IClassRepository _classRepository;

        public UserRepository(DBContext DBContext, IUserMapper userMapper, IClassRepository classRepository)
        {
            _dbContext = DBContext;
            _userMapper = userMapper;
            _classRepository = classRepository;
        }

        public async Task<User> GetUserById(long id)
        {
            return await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserDTOBase> GetUserDTOById(long id)
        {
            User user = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _userMapper.MapToDTO(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<UserDTOBase>> GetUsersDTOByClass(int classNumber)
        {
            List<User> users = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Where(x => x.Class.ClassNumber == classNumber)
                .ToListAsync();

            return users.Select(user => _userMapper.MapToDTO(user)).ToList();
        }

        public async Task<List<User>> GetUsersByClass(int classNumber)
        {
            return await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Where(x => x.Class.ClassNumber == classNumber)
                .ToListAsync();
        }

        public async Task<List<UserDTOBase>> GetAllUsersDTO()
        {
            List<User> users = await _dbContext.Users
                 .Include(x => x.Role)
                 .Include(x => x.Class)
                     .ThenInclude(x => x.Period)
                 .ToListAsync();

            return users.Select(user => _userMapper.MapToDTO(user)).ToList();
        }

        public async Task<List<UserDTOBase>> GetUsersDTOByClassWithPagination(int classNumber, int pageNumber, int pageSize)
        {
            var users = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Where(x => x.Class.ClassNumber == classNumber)
                .ToListAsync();

            var pagedUsers = users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return pagedUsers.Select(user => _userMapper.MapToDTO(user)).ToList();
        }

        public async Task<List<UserDTOBase>> GetAllUsersDTOWithPagination(int pageNumber, int pageSize)
        {
            var users = await _dbContext.Users
                 .Include(x => x.Role)
                 .Include(x => x.Class)
                     .ThenInclude(x => x.Period)
                 .ToListAsync();

            var pagedUsers = users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return pagedUsers.Select(user => _userMapper.MapToDTO(user)).ToList();
        }


        public async Task<UserDTOBase> CreateUser(UserCreateDTO userCreate, string createdBy)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userCreate.Password);
            userCreate.Password = hashedPassword;

            User user = _userMapper.MapToEntity(userCreate);

            Class @class = await _classRepository.GetClassByClassNumberAndPeriod(user.Class.ClassNumber, user.Class.Period.Number) ?? throw new InvalidOperationException("Classe não encontrada");
            user.ClassId = @class.Id;
            user.Class = @class;
            user.Class.Period = @class.Period;
            user.Class.PeriodId = @class.PeriodId;
            user.CreatedAt = DateTime.UtcNow;
            user.CreatedBy = createdBy;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(user);
        }

        public async Task<UserDTOBase> UpdateUser(User user, long id, string updateBy)
        {
            User userById = await GetUserById(id) ?? throw new Exception($"Usuário de ID: {id} não encontrado");
            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Phone = user.Phone;
            userById.ClassId = user.ClassId;
            userById.Pronoun = user.Pronoun;
            userById.RoleId = user.RoleId;
            userById.UpdatedBy = updateBy;
            userById.UpdatedAt = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(user.Password))
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                userById.Password = hashedPassword;
            }

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(userById);
        }

        public async Task<UserDTOBase> ChangeUserClass(long userId, int newClassNumber, string updateBy)
        {
            User user = await _dbContext.Users
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .FirstOrDefaultAsync(x => x.Id == userId) ?? throw new Exception($"Usuário de ID: {userId} não encontrado");
            Class newClass = await _dbContext.Classes.FirstOrDefaultAsync(x => x.ClassNumber == newClassNumber) ?? throw new Exception($"Classe de número: {newClassNumber} não encontrado");
            user.ClassId = newClass.Id;
            user.UpdatedBy = updateBy;
            user.UpdatedAt = DateTime.UtcNow;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(user);
        }

        public async Task<UserDTOBase> ChangeUserRole(long userId, long roleId, string updateBy)
        {
            User user = await _dbContext.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == userId) ?? throw new Exception($"Usuário de ID: {userId} não encontrado");
            Role role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == roleId) ?? throw new Exception($"Cargo de ID: {roleId} não encontrado");

            user.RoleId = roleId;
            user.UpdatedBy = updateBy;
            user.UpdatedAt = DateTime.UtcNow;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(user);
        }

        public async Task<bool> DeleteUser(long id)
        {
            User userById = await GetUserById(id) ?? throw new Exception($"Usuário de ID: {id} não encontrado");
            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteUser(long id, string updateBy)
        {
            User userById = await GetUserById(id) ?? throw new Exception($"Usuário de ID: {id} não encontrado");

            userById.IsDeleted = true;
            userById.UpdatedBy = updateBy;
            userById.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
