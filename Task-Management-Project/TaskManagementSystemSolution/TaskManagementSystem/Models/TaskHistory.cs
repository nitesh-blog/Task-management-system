namespace TaskManagementSystem.Models
{
    public class TaskHistory
    {
        public int TaskHistoryId { get; set; }
        public string Description { get; set; }
        public DateTime ChangedAt { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
