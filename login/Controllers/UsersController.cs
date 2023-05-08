using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using AutoMapper;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUsersService _usersService;
        IMapper _mapper;
        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user = await _usersService.GetUserById(id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO != null ? userDTO : NoContent();
        }

        // POST api/<UserController>
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserDTO userDto)
        {            
            User newUser = _mapper.Map<UserDTO,User >(userDto);
            User user =await _usersService.Login(newUser);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);

            if (userDTO == null)
                return Unauthorized();
            return Ok(userDTO);

        }

        [HttpPost("register")]
        public async Task<ActionResult?> Register([FromBody] UserDTO newUserDTO)
        {
            User newUser = _mapper.Map<UserDTO, User>(newUserDTO);
            User user = await _usersService.Register(newUser);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO != null ? CreatedAtAction(nameof(Get), new { id = userDTO.UserId }, userDTO) : BadRequest();
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDTO userToUpdateDTO)
        {
            User updatedUser = _mapper.Map<UserDTO, User>(userToUpdateDTO);
            await _usersService.UpdateUser(id, updatedUser);

        }
    }
}
