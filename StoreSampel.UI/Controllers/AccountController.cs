using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreSampel.Domain.Identity;
using StoreSampel.UI.Models.AccountViewModel;

namespace StoreSampel.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

       




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_signInManager.IsSignedIn(User))
                {
                    return Redirect("/");
                }

                var user = await _userManager.FindByEmailAsync(model.UserName);
                if (user != null)
                {
                
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "نام کاربری وگذرواژه اشتباه می باشد!");
                }

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var findUser = await _userManager.FindByEmailAsync(model.Email);
                if (findUser == null)
                {
                    var user = new ApplicationUser()
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        FullName = model.FullName
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (!await _userManager.IsInRoleAsync(user, "User"))
                    {
                        await _roleManager.CreateAsync(new ApplicationRole("User"));
                       
                       await _userManager.AddToRoleAsync(user, "User");
                    }
                    
                  
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "ایمیل موجود در سایت ثبت نام کرده!");
                }
            }

            return View(model);
        }
    }
}