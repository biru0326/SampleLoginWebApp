using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    // SignupController.cs
    public class SignupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SignupController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.Username == model.Username);
                if (user != null)
                {
                    ModelState.AddModelError("", "User already exists");
                    return View("Index", model);
                }
                    // TODO: Add password hashing and other validation
                _context.Users.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index", "Login");
            }

            return View("Index", model);
        }
    }

}
