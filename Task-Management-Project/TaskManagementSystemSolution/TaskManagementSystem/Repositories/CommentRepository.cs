using TaskManagementSystem.Data_DBContext_and_Seeding;
using TaskManagementSystem.DTOs;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<CommentDTO> GetCommentByTask(int taskId);
        void AddComment(TaskComment comment);
    }

    public class CommentRepository : ICommentRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public CommentRepository(TaskManagementDbContext dbContext) {
            _dbContext = dbContext;
        }
        public void AddComment(TaskComment comment)
        {
            _dbContext.TaskComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public IEnumerable<CommentDTO> GetCommentByTask(int taskId)
        {
          return _dbContext.TaskComments.Where(c => c.TaskId == taskId).Select(c => new CommentDTO 
          { 
            CommentId = c.TaskCommentId,
            CommentText = c.CommentText,
            TaskId = c.TaskId,
            UserId = c.UserId,
            CreatedAt = c.CreatedAt
          }).ToList();
        }
    }
}
