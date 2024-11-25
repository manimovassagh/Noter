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
    public class ShowAllController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowAllController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display the list of todos for the current logged-in user
        public IActionResult All()
        {
            
            // Fetch todos for the current user
            var todos = _context.TodoItems
                .ToList();

            return View(todos);
        }

        // Error handler
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}