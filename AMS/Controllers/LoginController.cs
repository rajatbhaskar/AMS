using AMS.Models;
using AMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Controllers

{
    public class LoginController : Controller
    {
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;
        public LoginController(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginVM modeldata)
        {

            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(modeldata.UserName,modeldata.Password,modeldata.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            ModelState.AddModelError("", "Login Failed");
            return View(modeldata);
        }

        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(RegisterVM modeldata)
        {
            if (ModelState.IsValid)
            {
                Users user = new()
                {
                    FullName = modeldata.Name,
                    Email = modeldata.Email,
                    UserName=modeldata.Email,
                    EnrollNumber = modeldata.EnrollNumber,  


                };
                var result=  await userManager.CreateAsync(user,modeldata.Password);
                if (result.Succeeded) 
                {
                    return RedirectToAction("UserLogin", "Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }
            return View();
        }

        public async Task<IActionResult> UserLogout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(LoginController.UserLogin));
        }
    }
}
