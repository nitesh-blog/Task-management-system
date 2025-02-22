namespace TaskManagementSystem.DTOs
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public string Taskname { get; set; }    
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public int CreatedByUserId { get; set; }
        public int AssignedToUserId {  get; set; }
        public  string Priority { get; set; }
    }
}
