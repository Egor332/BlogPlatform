using BlogPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserController(UserManager<ApplicationUser> userManager) { _userManager = userManager; }

        public IActionResult Index()
        {
            return View();
        }

        // GET request
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User); // only logged user can modify himself
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel
            {
                Id = user.Id,
                PublicName = user.PublicName,
                Bio = user.Bio,
                BirthDate = user.BirthDate
            };
            return View(model);
        }

        // POST request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();                
            }
            user.PublicName = model.PublicName;
            user.Bio = model.Bio;
            user.BirthDate = model.BirthDate;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
    }
}
