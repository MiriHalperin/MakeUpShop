using entities;

namespace Repository
{
    public interface IUsersRepository
    {
        User AddUser(User newUser);
        User FindUser(User userToFind);
        User GetUser(int id);
        bool IsUserNameExist(string Email);
        void UpdateUser(int id, User userToUpdate);
    }
}