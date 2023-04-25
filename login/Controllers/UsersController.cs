﻿using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // POST api/<UserController>
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] User userFromBody)
        {
            User user = _usersService.Login(userFromBody);
            if (user == null)
                return Unauthorized();
            return Ok(user);

        }

        [HttpPost]
        public ActionResult<User> Register([FromBody] User newUser)
        {
            User userCreated = _usersService.Register(newUser);
            if (userCreated != null)
                return Ok(userCreated);
            return BadRequest("user name exist");
        }

        [HttpPost("password")]
        public int checkPassword([FromBody] string password)
        {
            return _usersService.GetPasswordRate(password);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            if (_usersService.UpdateUser(id, userToUpdate))
                return userToUpdate;
            return BadRequest("user name exist");
            
        }
    }
}
