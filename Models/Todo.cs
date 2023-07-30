namespace Web1001_TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}