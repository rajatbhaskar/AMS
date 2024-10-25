using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers
{
    public class Login : Controller
    {
        public IActionResult UserLogin()
        {
            return View();
        }

        public IActionResult UserRegister()
        {
            return View();
        }

        public IActionResult UserLogout()
        {
            return View();
        }
    }
}
