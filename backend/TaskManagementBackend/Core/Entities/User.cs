namespace TaskManagementBackend.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // Navigation property for related tasks
        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    }
}
