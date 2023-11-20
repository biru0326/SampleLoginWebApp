using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    // MyAccountController.cs
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Add logic to retrieve user information based on authentication status
            return View();
        }
    }

}
