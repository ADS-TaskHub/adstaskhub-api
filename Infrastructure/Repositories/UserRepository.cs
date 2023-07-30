using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Helpers.ErrorMessages;
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
            User user = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user != null && !user.IsDeleted)
            {
                return user;
            }

            return null;
        }

        public async Task<UserDTOBase> GetUserDTOByIdAsync(long id)
        {
            User user = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user != null && !user.IsDeleted)
            {
                return _userMapper.MapToDTO(user);
            }

            return null;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            User user = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user != null && !user.IsDeleted)
            {
                return user;
            }

            return null;
        }

        public async Task<List<UserDTOBase>> GetUsersDTOByClassAsync(int classNumber)
        {
            List<User> users = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Where(x => x.Class.ClassNumber == classNumber)
                .ToListAsync();

            List<UserDTOBase> userDTOs = users
                .Where(user => !user.IsDeleted)
                .Select(user => _userMapper.MapToDTO(user))
                .ToList();

            if (userDTOs.Any())
            {
                return userDTOs;
            }

            return null;
        }

        public async Task<List<User>> GetUsersByClassAsync(int classNumber)
        {
            List<User> users = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Where(x => x.Class.ClassNumber == classNumber)
                .ToListAsync();

            List<User> validUsers = users.Where(user => !user.IsDeleted).ToList();

            if (validUsers.Any())
            {
                return validUsers;
            }

            return null;
        }

        public async Task<List<UserDTOBase>> GetAllUsersDTOAsync()
        {
            List<User> users = await _dbContext.Users
                 .Include(x => x.Role)
                 .Include(x => x.Class)
                     .ThenInclude(x => x.Period)
                 .ToListAsync();

            List<UserDTOBase> userDTOs = users
                .Where(user => !user.IsDeleted)
                .Select(user => _userMapper.MapToDTO(user))
                .ToList();

            if (userDTOs.Any())
            {
                return userDTOs;
            }

            return null;
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
                .Where(user => !user.IsDeleted)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            List<UserDTOBase> userDTOs = pagedUsers
                .Select(user => _userMapper.MapToDTO(user))
                .ToList();

            if (userDTOs.Any())
            {
                return userDTOs;
            }

            return null;
        }

        public async Task<List<UserDTOBase>> GetAllUsersDTOWithPaginationAsync(int pageNumber, int pageSize)
        {
            var users = await _dbContext.Users
                 .Include(x => x.Role)
                 .Include(x => x.Class)
                     .ThenInclude(x => x.Period)
                 .ToListAsync();

            var pagedUsers = users
                .Where(user => !user.IsDeleted)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            List<UserDTOBase> userDTOs = pagedUsers
                .Select(user => _userMapper.MapToDTO(user))
                .ToList();

            if (userDTOs.Any())
            {
                return userDTOs;
            }

            return null;
        }

        public async Task<List<User>> GetNotApprovedUsersAsync()
        {
            List<User> users = await _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .Where(user => !user.IsApproved)
                .ToListAsync();

            List<User> validUsers = users.Where(user => !user.IsDeleted).ToList();

            if (validUsers.Any())
            {
                return validUsers;
            }

            return null;
        }

        public async Task<UserDTOBase> CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(user);
        }

        public async Task<UserDTOBase> UpdateUserAsync(User user, long id)
        {
            User userById = await GetUserByIdAsync(id) ?? throw new Exception(UserErrorMessages.UserNotFound);
            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Phone = user.Phone;
            userById.ClassId = user.ClassId;
            userById.Pronoun = user.Pronoun;
            userById.RoleId = user.RoleId;
            userById.Password = user.Password;
            userById.UpdatedAt = DateTime.UtcNow;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(userById);
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            User userById = await GetUserByIdAsync(id) ?? throw new Exception(UserErrorMessages.UserNotFound);

            if (userById.IsDeleted)
            {
                throw new Exception(UserErrorMessages.UserNotFound);
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
