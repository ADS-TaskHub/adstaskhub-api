using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;
        private readonly IUserMapper _userMapper;

        public UserRepository(DBContext DBContext, IUserMapper userMapper)
        {
            _dbContext = DBContext;
            _userMapper = userMapper;
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            return await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserDTOBase> GetUserDTOByIdAsync(long id)
        {
            User user = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _userMapper.MapToDTO(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<UserDTOBase>> GetUsersDTOByClassAsync(int classNumber)
        {
            List<User> users = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Where(x => x.Class.ClassNumber == classNumber)
                .ToListAsync();

            return users.Select(user => _userMapper.MapToDTO(user)).ToList();
        }

        public async Task<List<User>> GetUsersByClassAsync(int classNumber)
        {
            return await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Where(x => x.Class.ClassNumber == classNumber)
                .ToListAsync();
        }

        public async Task<List<UserDTOBase>> GetAllUsersDTOAsync()
        {
            List<User> users = await _dbContext.Users
                 .Include(x => x.Role)
                 .Include(x => x.Class)
                     .ThenInclude(x => x.Period)
                 .ToListAsync();

            return users.Select(user => _userMapper.MapToDTO(user)).ToList();
        }

        public async Task<List<UserDTOBase>> GetUsersDTOByClassWithPaginationAsync(int classNumber, int pageNumber, int pageSize)
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

        public async Task<List<UserDTOBase>> GetAllUsersDTOWithPaginationAsync(int pageNumber, int pageSize)
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


        public async Task<UserDTOBase> CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(user);
        }

        public async Task<UserDTOBase> UpdateUserAsync(User user, long id)
        {
            User userById = await GetUserByIdAsync(id) ?? throw new Exception($"Usuário de ID: {id} não encontrado");
            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Phone = user.Phone;
            userById.ClassId = user.ClassId;
            userById.Pronoun = user.Pronoun;
            userById.RoleId = user.RoleId;
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

        public async Task<bool> DeleteUserAsync(long id)
        {
            User userById = await GetUserByIdAsync(id) ?? throw new Exception($"Usuário de ID: {id} não encontrado");
            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
