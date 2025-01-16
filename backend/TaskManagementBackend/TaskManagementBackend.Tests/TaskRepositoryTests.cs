using Microsoft.EntityFrameworkCore;
using TaskManagementBackend.Core.Entities;
using TaskManagementBackend.Infrastructure.Data;
using TaskManagementBackend.Infrastructure.Repositories;
using Xunit;
using System.Threading.Tasks;

namespace TaskManagementBackend.Tests
{
    public class TaskRepositoryTests
    {
        private readonly TaskManagementDbContext _context;
        private readonly TaskRepository _repository;

        public TaskRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<TaskManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "TaskManagementTestDb")
                .Options;

            _context = new TaskManagementDbContext(options);
            _repository = new TaskRepository(_context);
        }

        [Fact]
        public async Task AddTask_ShouldAddTaskSuccessfully()
        {
            // Arrange
            var task = new TaskEntity
            {
                Title = "Test Task",
                Description = "Test Description",
                Status = "Pending",
                UserId = 1
            };

            // Act
            var result = await _repository.AddTask(task);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(task.Title, result.Title);
        }

        [Fact]
        public async Task GetAllTasks_ShouldReturnTasks()
        {
            // Arrange
            _context.Tasks.Add(new TaskEntity { Title = "Task 1", UserId = 1 });
            _context.Tasks.Add(new TaskEntity { Title = "Task 2", UserId = 1 });
            await _context.SaveChangesAsync();

            // Act
            var tasks = await _repository.GetAllTasks(1);

            // Assert
            Assert.Equal(2, tasks.Count());
        }

        [Fact]
        public async Task GetTaskById_ShouldReturnCorrectTask()
        {
            // Arrange
            var task = new TaskEntity { Title = "Find Me", UserId = 1 };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetTaskById(task.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Find Me", result.Title);
        }

        [Fact]
        public async Task UpdateTask_ShouldUpdateTaskSuccessfully()
        {
            // Arrange
            var task = new TaskEntity { Title = "Old Title", UserId = 1 };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            task.Title = "Updated Title";

            // Act
            var result = await _repository.UpdateTask(task);

            // Assert
            Assert.Equal("Updated Title", result.Title);
        }

        [Fact]
        public async Task DeleteTask_ShouldRemoveTaskSuccessfully()
        {
            // Arrange
            var task = new TaskEntity { Title = "Delete Me", UserId = 1 };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            // Act
            await _repository.DeleteTask(task.Id);
            var result = await _repository.GetTaskById(task.Id);

            // Assert
            Assert.Null(result);
        }
    }
}
