using TaskManagementSystem.DTOs;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetCommentsByTask(int taskId);
        void AddComment(TaskComment comment);


    }
    public class CommentService: ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void AddComment(TaskComment comment)
        {
            _commentRepository.AddComment(comment);
        }

        public IEnumerable<CommentDTO> GetCommentsByTask(int taskId)
        {
            return _commentRepository.GetCommentByTask(taskId);
        }
    }
}
