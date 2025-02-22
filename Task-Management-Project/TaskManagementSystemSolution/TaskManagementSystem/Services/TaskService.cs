using TaskManagementSystem.DTOs;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskDTO> GetAllTask();
        void CreateTask(Models.Task task);
        TaskDTO UpdateTaskStatus(int id, string status);
        void AssignTask(int taskId, int userId);

    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public IEnumerable<TaskDTO> GetAllTask()
        {
            return _taskRepository.GetTasks();
        }

        public void CreateTask(Models.Task task)
        {
            _taskRepository.AddTask(task);
        }

        public TaskDTO UpdateTaskStatus(int id, string status)
        {
            return _taskRepository.UpdateTaskStatus(id, status);
        }

        public void AssignTask(int taskId, int userId)
        {
            _taskRepository.AssignTask(taskId, userId);
        }

        

    }
}
