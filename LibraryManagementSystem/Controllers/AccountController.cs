using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller

    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel UserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = UserVM.FirstName + " " + UserVM.LastName,
                    FirstName = UserVM.FirstName,
                    LastName = UserVM.LastName,
                    Email = UserVM.Email,
                    RegistrationDate = DateTime.Now
                };
                IdentityResult Result = await userManager.CreateAsync(user, UserVM.Password);
                if (Result.Succeeded)
                {
                    // Make sure the "User" role exists before this call
                    await userManager.AddToRoleAsync(user, "User"); // THIS IS THE KEY LINE

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("userbrowse", "Book");
                }
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View("Register", UserVM);
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel UserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(UserVM.UserName);
                if (user != null)
                {
                    bool result = await userManager.CheckPasswordAsync(user, UserVM.Password);
                    if (result)
                    {
                        // Sign in the user
                        await signInManager.SignInAsync(user, isPersistent: UserVM.RememberMe);

                        // Check role and redirect accordingly
                        if (await userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return RedirectToAction("Index", "Book");
                        }
                        else
                        {
                            return RedirectToAction("UserBrowse", "Book");
                        }
                    }
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }
            return View("Login", UserVM);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

        }
    }
}
