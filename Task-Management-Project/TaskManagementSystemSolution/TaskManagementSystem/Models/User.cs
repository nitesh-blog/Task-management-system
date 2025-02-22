namespace TaskManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
        
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

       public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<TaskComment> TaskComments { get; set; }

        public ICollection<Task> CreatedTasks { get; set; }
        public ICollection<Task> AssignedTask { get; set; }


    }
}
