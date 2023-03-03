using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class UsersService
    {
        UsersRepository repository = new UsersRepository();
        public User Login(User user)
        {
            return repository.FindUser(user);
        }

        public User Register(User newUser)
        {
            if (GetPasswordRate(newUser.Password)>=2&&!repository.IsUserNameExist(newUser.Email))
                return repository.AddUser(newUser);
            return null;
        }

        public Boolean UpdateUser(int id,User userToUpdate)
        {
            User user = repository.GetUser(id);
            //if(!user) return false
            if (user.Email != userToUpdate.Email && repository.IsUserNameExist(userToUpdate.Email))
                return false;
            repository.UpdateUser(id, userToUpdate);
            return true;
        }

        public int GetPasswordRate(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
