using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Model;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> GetTaskById(int id)
        {
            TaskModel task = await _taskRepository.GetTaskById(id);
            return Ok(task);
        }
        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.AddTask(taskModel);
            return Ok(task);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRepository.UpdateTask(taskModel, id);
            return Ok(task);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id) { 
        bool deleted = await _taskRepository.DeleteTask(id);
        return Ok(deleted); 
    }
    }
}
