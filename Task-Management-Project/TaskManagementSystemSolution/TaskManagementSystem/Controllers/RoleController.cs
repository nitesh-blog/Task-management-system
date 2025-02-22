using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController :ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public IActionResult CreateRole([FromBody] Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _roleService.CreateRole(role);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetRole()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpPost("Assign")]
        public IActionResult AssignRole(int userId,int roleId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            _roleService.AssignRole(userId,roleId);
            return Ok();
        }

    }
}
