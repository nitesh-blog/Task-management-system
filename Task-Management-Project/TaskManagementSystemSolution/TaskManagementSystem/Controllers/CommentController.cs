using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("Task/{taskId}")]
        public IActionResult GetCommentByTask(int taskId)
        {
            var comments = _commentService.GetCommentsByTask(taskId);
            if (comments == null)
                return NotFound();
            return Ok(comments);
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] TaskComment comment)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            _commentService.AddComment(comment);
            return Ok();
        }
    }
}
