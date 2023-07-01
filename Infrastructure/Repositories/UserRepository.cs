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

        public async Task<User> GetUserById(long id)
        {
            return await _dbContext.users
                .Include(x => x.Role)
                .Include(x => x.Class)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserDTO> GetUserDTOById(long id)
        {
            User user = await _dbContext.users
                .Include(x => x.Role)
                .Include(x => x.Class)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _userMapper.MapToDTO(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.users
                .Include(x => x.Role)
                .Include(x => x.Class)
                    .ThenInclude(x => x.Period)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<UserDTO>> GetAllUsersDTO()
        {
            List<User> users = await _dbContext.users
                 .Include(x => x.Role)
                 .Include(x => x.Class)
                     .ThenInclude(x => x.Period)
                 .ToListAsync();

            return users.Select(user => _userMapper.MapToDTO(user)).ToList();
        }

        public async Task<UserDTO> CreateUser(User user)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Password = hashedPassword;

            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(user);
        }

        public async Task<UserDTO> UpdateUser(User user, long id)
        {
            User userById = await GetUserById(id) ?? throw new Exception($"User for ID: {id} not found");
            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Phone = user.Phone;
            userById.ClassId = user.ClassId;
            userById.Pronoun = user.Pronoun;
            userById.RoleId = user.RoleId;

            if (!string.IsNullOrEmpty(user.Password))
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                userById.Password = hashedPassword;
            }

            _dbContext.users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return _userMapper.MapToDTO(userById);
        }

        public async Task<bool> DeleteUser(long id)
        {
            User userById = await GetUserById(id) ?? throw new Exception($"User for ID: {id} not found");
            _dbContext.users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
