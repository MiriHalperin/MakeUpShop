using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class UsersService : IUsersService
    {
        IUsersRepository _UserRepository;
        public UsersService(IUsersRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public User Login(User user)
        {
            return _UserRepository.FindUser(user);
        }

        public User Register(User newUser)
        {
            if (GetPasswordRate(newUser.Password) >= 2 && !_UserRepository.IsUserNameExist(newUser.Email))
                return _UserRepository.AddUser(newUser);
            return null;
        }

        public Boolean UpdateUser(int id, User userToUpdate)
        {
            User user = _UserRepository.GetUser(id);
            //if(!user) return false
            if (user.Email != userToUpdate.Email && _UserRepository.IsUserNameExist(userToUpdate.Email))
                return false;
            _UserRepository.UpdateUser(id, userToUpdate);
            return true;
        }

        public int GetPasswordRate(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
