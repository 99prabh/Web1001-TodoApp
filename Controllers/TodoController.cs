using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web1001_TodoApp.Models;

namespace Web1001Todo.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoDbContext _context;

        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        // GET: Todo/Index
        public async Task<IActionResult> Index()
        {
            // Retrieve and display incomplete todos
            return View(await _context.Todos.Where(t => !t.IsComplete).ToListAsync());
        }

        // GET: Todo/MarkCompletedTodos
        [HttpGet]
        public async Task<IActionResult> MarkCompletedTodos()
        {
            // Retrieve and display completed todos
            return View(await _context.Todos.Where(t => t.IsComplete).ToListAsync());
        }

        // GET: Todo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Ensure id is provided and Todos are available in context
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }

            // Retrieve and display details of a specific todo
            var todo = await _context.Todos.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: Todo/Create
        public IActionResult Create()
        {
            // Display view for creating a new todo
            return View();
        }

        // POST: Todo/Create
        // Handle creation of a new todo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Details,IsComplete,CompleteDate")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Ensure id is provided and Todos are available in context
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }

            // Retrieve and display view for editing a specific todo
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: Todo/Edit
        // Handle editing of a todo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Details,IsComplete,CompleteDate")] Todo todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // Ensure id is provided and Todos are available in context
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }

            // Retrieve and display view for deleting a specific todo
            var todo = await _context.Todos.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: Todo/Delete/5
        // Handle deletion of a todo
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Todos == null)
            {
                return Problem("Entity set 'TodoDbContext.Todos' is null.");
            }
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Check if a todo with a specific id exists
        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}
