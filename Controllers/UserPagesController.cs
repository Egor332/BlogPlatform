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
            UserPage page = await _context.UserPages.FindAsync(id);
            return View();
        }
    }
}
