namespace TaskManagementSystem.DTOs
{
    public class TaskCreateDTO
    {
        public string TaskName { get; set; }
        public string Descrition { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedUserId { get; set; }
    }
}
