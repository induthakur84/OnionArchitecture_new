using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Data.Interface;
using OnionArchitecture.Domain.DTO;
using OnionArchitecture.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //[HttpGet("GetAll")]
        //public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
        //{
        //    var users= await _userService.GetAll();
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(users);
        //}

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
        {
            var users = await _userService.GetAll();

            if (users == null)
            {
                return NotFound();
            }

            return users.ToList(); 
        }


        [HttpGet("GetbyId")]






        // what is IActionResult and Actionresult?


        // what are status code?

        //200 ok means the request is successfully created and the response is returned succesfuuly
        //201 new record
        //400 bad request
        //404 not found
        // 500 internal server error
        //204 deleted the records
        //




        //system versioning
        //relationships

        // user have one studentid
    }
}
