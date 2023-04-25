using entities;

namespace Service
{
    public interface IUsersService
    {
        int GetPasswordRate(string password);
        User Login(User user);
        User Register(User newUser);
        bool UpdateUser(int id, User userToUpdate);
    }
}