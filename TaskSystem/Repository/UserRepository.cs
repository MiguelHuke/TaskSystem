using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Model;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDbContext _dbContext;
        public UserRepository(TaskSystemDbContext dbContext) { 
        _dbContext = dbContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);
            if (userById == null) {
                throw new Exception($"User for ID: {id} not found");
                    }
            userById.FirstName = user.FirstName;
            userById.LastName = user.LastName;
            userById.Username = user.Username;
            userById.Email = user.Email;
            userById.Password = user.Password;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }
        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);
            if (userById == null)
            {
                throw new Exception($"User for ID: {id} not found");
            }
            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

      
    }
}
