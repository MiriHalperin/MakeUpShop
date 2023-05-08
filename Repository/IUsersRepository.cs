using entities;

namespace Repository
{
    public interface IUsersRepository
    {
        Task<User> AddUser(User newUser);
        Task<User> FindUser(User userToFind);
        Task<bool> IsUserNameExist(string Email);
        Task UpdateUser(User updatedUser, int id);      
         Task<User> getUserById(int id);

    }
}