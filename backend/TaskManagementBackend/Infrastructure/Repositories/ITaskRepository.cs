using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementBackend.Core.Entities;

namespace TaskManagementBackend.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetAllTasks(int userId);
        Task<TaskEntity> GetTaskById(int id);
        Task<TaskEntity> AddTask(TaskEntity task);
        Task<TaskEntity> UpdateTask(TaskEntity task);
        Task DeleteTask(int id);
    }
}
