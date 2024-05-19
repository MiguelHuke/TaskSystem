using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Model;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDbContext _dbContext;
        public TaskRepository(TaskSystemDbContext dbContext) { 
        _dbContext = dbContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskById = await GetTaskById(id);
            if (taskById == null) {
                throw new Exception($"Task for ID: {id} not found");
                    }
            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }
        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await GetTaskById(id);
            if (taskById == null)
            {
                throw new Exception($"Task for ID: {id} not found");
            }
            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        }
    }

