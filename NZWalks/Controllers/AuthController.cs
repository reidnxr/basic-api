using Microsoft.AspNetCore.Mvc;
using Models;
using Services.IServices;
using System.Xml;

namespace Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Models.DTO.Login login)
        {
            User user = await _userService.Authentication(login.email, login.password);
            if (user == null)
            {
                return BadRequest("Email or password is incorrect");
            }
            string token = await _tokenService.CreateToken(user);
            return Ok(token);
        }
    }
}
