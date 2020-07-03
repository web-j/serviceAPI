using System.Collections.Generic;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;

        public UserController(IApplicationServiceUser applicationServiceUser)
        {
            _applicationServiceUser = applicationServiceUser;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceUser.GetAll());
        }
    }
}