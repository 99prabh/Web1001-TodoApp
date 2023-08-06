namespace Web1001_TodoApp.Models
{
    // Model class for representing a todo item
    public class Todo
    {
        public int Id { get; set; } // Unique identifier for the todo
        public string Title { get; set; } // Title of the todo
        public string Details { get; set; } // Details or description of the todo
        public bool IsComplete { get; set; } // Completion status of the todo
        public DateTime? CompleteDate { get; set; } // Date when the todo was completed (nullable)
    }
}
