using TaskSystem.Model;

namespace TaskSystem.Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTask (TaskModel task);
        Task<TaskModel> UpdateTask (TaskModel task, int id);
        Task<bool> DeleteTask (int id);
    }
}
