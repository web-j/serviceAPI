using System;
using System.Collections.Generic;
using Application.Interfaces;
using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceUser.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Add(userDTO);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Update(userDTO);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public ActionResult Remove([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Remove(userDTO);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // execution time
        [HttpGet]
        [Route("erasedList")]
        public ActionResult<IEnumerable<string>> GetAllErased()
        {
            return Ok(_applicationServiceUser.GetAllErased());
        }

        [HttpPut]
        [Route("deactivate")]
        public ActionResult Erase([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Deactivate(userDTO);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("deactivateList")]
        public ActionResult RemoveList([FromBody] IEnumerable<UserDTO> userDTOs)
        {
            try
            {
                if (userDTOs == null)
                    return NotFound();

                _applicationServiceUser.DeactivateList(userDTOs);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}