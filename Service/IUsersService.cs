using entities;

namespace Service
{
    public interface IUsersService
    {
        Task<User> Login(User user);
        Task<User> Register(User newUser);
        Task UpdateUser(int id, User userToUpdate);
        Task<User> GetUserById(int id);

    }
}