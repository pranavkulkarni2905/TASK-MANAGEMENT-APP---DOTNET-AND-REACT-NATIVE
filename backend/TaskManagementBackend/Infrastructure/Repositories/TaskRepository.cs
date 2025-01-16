using Microsoft.EntityFrameworkCore;
using TaskManagementBackend.Core.Entities;
using TaskManagementBackend.Core.Interfaces;
using TaskManagementBackend.Infrastructure.Data;

namespace TaskManagementBackend.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDbContext _context;

        public TaskRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasks(int userId)
        {
            return await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<TaskEntity> GetTaskById(int id)
        {
            
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskEntity> AddTask(TaskEntity task)
        {
            var result = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TaskEntity> UpdateTask(TaskEntity task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
