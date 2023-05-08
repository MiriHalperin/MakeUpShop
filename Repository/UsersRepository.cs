using System.Text.Json;
using entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UsersRepository : IUsersRepository
    {
        MakeUpContext _makeUpContext;

        public UsersRepository(MakeUpContext makeUpContext)
        {
            _makeUpContext = makeUpContext;
        }
        static private string filePath = "..\\users.JSON";
        public async Task<User> getUserById(int id)
        {
            User? user = await _makeUpContext.Users.FindAsync(id);
            User? user2 = await _makeUpContext.Users.Where(u => u.UserId == id).Include(u => u.Orders).FirstOrDefaultAsync();
            return user2 != null ? user2 : null;
        }
        public async Task<User> FindUser(User userToFind)
        {
            var users = await _makeUpContext.Users.Where(user => user.Email == userToFind.Email && user.Password == userToFind.Password).ToListAsync();
            return users.Count() == 0 ? null : users[0];
        }
        public async Task<bool> IsUserNameExist(string Email)
        {
            User? user2 = await _makeUpContext.Users.Where(u => u.Email == Email).FirstOrDefaultAsync();
            if (user2 == null)
                return false;
            else
                return true;
           
        }
        public async Task<User> AddUser(User newUser)
        {
            await _makeUpContext.Users.AddAsync(newUser);
            await _makeUpContext.SaveChangesAsync();
            return newUser;
        }
        public async Task UpdateUser(User updatedUser, int id)
        {
            User userToUpdate = await _makeUpContext.Users.FindAsync(id);
            if (userToUpdate != null)
            {
                _makeUpContext.Entry(userToUpdate).CurrentValues.SetValues(updatedUser);
                await _makeUpContext.SaveChangesAsync();
            }

        }

       
       
    }
}
