using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    // LoginController.cs
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(User model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                // TODO: Add authentication logic (e.g., set authentication cookies)
                return RedirectToAction("Index", "MyAccount");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View("Index", model);
        }
    }

}
