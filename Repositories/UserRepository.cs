using adstaskhub_api.Data;
using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;

        public UserRepository(DBContext DBContext)
        {
            _dbContext = DBContext;   
        }

        public async Task<User> GetUserById(long Id)
        {
            return await _dbContext.users.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.users.ToListAsync();
        }

        public async Task<User> CreateUser(User user)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Password = hashedPassword;

            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUser(User user, long id)
        {
            User userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User for ID: {id} not found");
            }

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
            return userById;
        }


        public async Task<bool> DeleteUser(long id)
        {
            User userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User for ID: {id} not found");
            }

            _dbContext.users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
