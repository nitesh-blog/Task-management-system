namespace TaskManagementSystem.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
