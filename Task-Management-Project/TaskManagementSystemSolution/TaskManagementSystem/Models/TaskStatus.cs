namespace TaskManagementSystem.Models
{
    public class TaskStatus
    {
        public int TaskStatusId { get; set; }
        public string statusName { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
