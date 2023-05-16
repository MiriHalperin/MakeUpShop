using Service;
using entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        IPasswordService passwordService;

        public PasswordController(IPasswordService passwordBusiness)
        {
            this.passwordService = passwordBusiness;
        }
        // POST api/<PasswordController>
        [HttpPost]

        public async Task<int> passwordStrength([FromBody] string pwd)
        {
            return await passwordService.goodPassword(pwd);
        }


    }
}
