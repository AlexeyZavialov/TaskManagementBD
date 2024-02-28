namespace TaskManagementBD.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime ExecutionTime { get; set; }
        public bool IsCompleted { get; set; }


    }
}
