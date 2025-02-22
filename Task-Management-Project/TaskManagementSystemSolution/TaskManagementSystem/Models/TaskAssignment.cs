namespace TaskManagementSystem.Models
{
    public class TaskAssignment
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
