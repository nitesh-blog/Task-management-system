namespace TaskManagementSystem.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public  int  TaskStatusId { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public string TaskStatuses {  get; set; } 
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }
        public int AssignedTo { get; set; }
        public User AssignedToUser { get; set; }
        public  ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<TaskComment> TaskComments { get; set; }

        public ICollection<TaskHistory> TaskHistory { get; set; }
    }
}
