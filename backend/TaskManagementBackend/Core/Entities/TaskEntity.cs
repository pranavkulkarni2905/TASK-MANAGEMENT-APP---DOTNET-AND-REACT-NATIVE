namespace TaskManagementBackend.Core.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public int UserId { get; set; }
        //public User User { get; set; } = null!;
    }
}
