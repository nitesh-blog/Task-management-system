using TaskManagementSystem.Data_DBContext_and_Seeding;
using TaskManagementSystem.DTOs;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskDTO> GetTasks();
        void AddTask(Models.Task task);
        TaskDTO UpdateTaskStatus(int id , string status);
        void AssignTask(int taskId, int userId);
        Models.Task GetTaskById(int id);
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TaskRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<TaskDTO> GetTasks()
        {
           return _dbContext.Tasks.Select(t => new TaskDTO
           {
               TaskId = t.TaskId,
               Taskname = t.TaskName,
               Description = t.Description,
               Status = t.TaskStatuses,
               DueDate = t.DueDate,
               CreatedByUserId=t.CreatedBy,
               AssignedToUserId = t.AssignedTo,
           }).ToList();
        }

        public void AddTask(Models.Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }

        public void AssignTask(int taskId, int userId)
        {
            var taskAssignment = new TaskAssignment
            {
                TaskId = taskId,
                UserId = userId
            };
            _dbContext.TaskAssignments.Add(taskAssignment);
            _dbContext.SaveChanges();
        }

        public Models.Task GetTaskById(int id)
        {
            return _dbContext.Tasks.Find(id);
        }

        public TaskDTO UpdateTaskStatus(int id, string status)
        {
           var task = _dbContext.Tasks.Find(id);
            if (task == null)
                return null;
                var taskStatus = _dbContext.TaskStatuses.FirstOrDefault(ts => ts.statusName == status);
                if (taskStatus == null)
                    return null;
                task.TaskStatusId = taskStatus.TaskStatusId;
                _dbContext.SaveChanges();
            return new TaskDTO
            {
                TaskId = task.TaskId,
                Taskname = task.TaskName,
                Description = task.Description,
                Status = task.TaskStatuses,
                DueDate = task.DueDate,
                AssignedToUserId = task.AssignedTo,
            };
        }
    }
}
