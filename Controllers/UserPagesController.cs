using BlogPlatform.Data;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    public class UserPagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserPagesController(ApplicationDbContext context) { _context = context; }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserPage page = await _context.UserPages.FindAsync();
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // GET request
        public IActionResult Create(string? token)
        {
            if (string.IsNullOrEmpty(token) || (token != TempData["CreateToken"]?.ToString()))
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, UserName, Bio, BirthDate, UserId")] UserPage page)
        {
            if (ModelState.IsValid)
            {
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", page.Id);
            }
            return View(page);
        }
    }
}
