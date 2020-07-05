using API.Security;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;

        public LoginController(IApplicationServiceUser applicationServiceUser)
        {
            _applicationServiceUser = applicationServiceUser;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] UserCredential credential)
        {
            var user = _applicationServiceUser.Authenticate(credential.Password, credential.Username, credential.Email);

            if (user == null)
                return NotFound(new { message = "Usuário ou Senha Inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                User = user,
                Token = token
            };
        }
    }
}