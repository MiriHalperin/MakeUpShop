using AutoMapper;
using entities;
using DTO;

namespace LoginEx
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, User>();

        }
    }
}
