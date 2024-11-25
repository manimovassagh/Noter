using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noter.Data;
using Noter.Models;

namespace Noter.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display the list of todos for the current logged-in user
        public IActionResult Index()
        {
            // Get the logged-in user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(); // Redirect unauthorized users
            }

            // Fetch todos for the current user
            var todos = _context.TodoItems
                .Where(todo => todo.UserId == userId)
                .ToList();

            return View(todos);
        }

        // Handle form submission to add a new todo
        [HttpPost]
        public IActionResult Add(string title, string? description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                ModelState.AddModelError("Title", "Title is required.");
                return RedirectToAction("Index");
            }

            // Get the logged-in user's ID and username
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userName))
            {
                return Unauthorized();
            }

            // Create a new TodoItem
            var newTodo = new TodoItem
            {
                Title = title,
                Description = description,
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                UserId = userId,
                UserName = userName // Store the username
            };

            // Save to the database
            _context.TodoItems.Add(newTodo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Mark a todo item as completed
        [HttpPost]
        public IActionResult MarkAsCompleted(int id)
        {
            var todo = _context.TodoItems.Find(id);

            if (todo == null)
            {
                return NotFound();
            }

            // Ensure the current user owns the todo item
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (todo.UserId != userId)
            {
                return Forbid();
            }

            todo.IsCompleted = true;
            _context.TodoItems.Update(todo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Error handler
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}