using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.DTOs;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
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
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = _userService.GetAllUser();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CretateUser([FromBody] User user)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
               _userService.CreateUser(user);
                return Ok(user);

        }
        [HttpPut("{id}")]
        public IActionResult UpdatedUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updateUser = _userService.UpdateUser(id, user);
            if (updateUser == null)
                return NotFound();
            return Ok(updateUser);
        }


    }
}
