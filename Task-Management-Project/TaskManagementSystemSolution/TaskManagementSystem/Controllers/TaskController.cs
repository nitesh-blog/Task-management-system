using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskService.GetAllTask();
            return Ok(tasks);
        }
        [HttpPost]
        public IActionResult CreateTask([FromBody] Models.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _taskService.CreateTask(task);
            return Ok();
        }

        [HttpPut("UpdateStatus/{id}")]
        public IActionResult UpdateTaskStatus(int id, string status)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updateTask = _taskService.UpdateTaskStatus(id, status);
            if (updateTask == null)
                return NotFound();
            return Ok(updateTask);
        }

        [HttpPost("Assign")]
        public IActionResult AssignTask(int taskId, int userId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            _taskService.AssignTask(taskId, userId);
            return Ok();
        }

    }
}
