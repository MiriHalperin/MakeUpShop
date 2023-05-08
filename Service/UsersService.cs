using entities;
using Repository;
using Service;
using Zxcvbn;


namespace Service
{
    public class UsersService : IUsersService                               
    {
        IUsersRepository _UserRepository;
        IPasswordService _passwordService;

        public UsersService(IUsersRepository UserRepository, IPasswordService passwordService)
        {
            _UserRepository = UserRepository;
            _passwordService= passwordService;

        }

        public async Task<User> Login(User user)
        {
            return await _UserRepository.FindUser(user);
        }

        public async Task<User> Register(User newUser)
        {
            if (await _passwordService.goodPassword(newUser.Password) >= 1)
                return await _UserRepository.AddUser(newUser);
            else
                return null;
        }

        public async Task UpdateUser(int id, User userToUpdate)
        {
            await _UserRepository.UpdateUser(userToUpdate,id);
        }


        public async Task<User> GetUserById(int id)
        {
            return await _UserRepository.getUserById(id);
        }
    }
}
