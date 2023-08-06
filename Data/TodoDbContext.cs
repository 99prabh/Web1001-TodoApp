using Microsoft.EntityFrameworkCore;

namespace Web1001_TodoApp.Models
{
    // DbContext class for interacting with the database
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        // DbSet representing the Todos table in the database
        public DbSet<Todo> Todos { get; set; }
    }
}
