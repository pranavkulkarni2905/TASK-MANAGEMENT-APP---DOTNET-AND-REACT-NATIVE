using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagementBackend.Core.Entities;
using TaskManagementBackend.Core.Interfaces;

namespace TaskManagementBackend.API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var userId = 1;  // This should be extracted from the JWT token in real application
            var tasks = await _taskRepository.GetAllTasks(userId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task == null)
                return NotFound("Task not found.");

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskEntity task)
        {
            if (task == null)
                return BadRequest("Invalid task data.");

            var createdTask = await _taskRepository.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskEntity task)
        {
            if (id != task.Id)
                return BadRequest("Task ID mismatch.");

            var existingTask = await _taskRepository.GetTaskById(id);
            if (existingTask == null)
                return NotFound("Task not found.");

            var updatedTask = await _taskRepository.UpdateTask(task);
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var existingTask = await _taskRepository.GetTaskById(id);
            if (existingTask == null)
                return NotFound("Task not found.");

            await _taskRepository.DeleteTask(id);
            return Ok("Task deleted successfully.");
        }
    }
}
