namespace Systemutviklerskolen_todo_app_backend
{
    public class Todo
    {
        public Guid Id { get; set; }

        public bool Done { get; set; }

        public string? Task { get; set; }

        public string PartitionKey => Id.ToString().Substring(0, 4);
    }
}