using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.ViewModel;
using Database.Entities;
using Database;
using Database.Repository;
using Microsoft.AspNetCore.Identity;

namespace src.Controllers
{
    public class AuthController : Controller
    {
        private LoginModel model;
        private IBoxUserRepository _userRepository;
        private SignInManager<BoxIdentityUser> _signInManager;

        public AuthController(IBoxUserRepository userRepository, SignInManager<BoxIdentityUser> signInManager)
        {
            model = new LoginModel();
            _userRepository = userRepository;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            ModelState.Remove($"{nameof(model.ConfirmPassword)}");
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.Username,
                                                                                model.Password,
                                                                                true, false);
                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                }
            }
            else
            {
                ModelState.AddModelError("ModelInvalid", "Some field are incorrect.");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("index", "home");
        }

        public IActionResult Register()
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginModel model)
        {
            var userAlreadyExist = await ResolveNewUserEmail(model.Username);
            if (userAlreadyExist)
            {
                ModelState.AddModelError("", "User already exist with this email.");
                return View();
            }
            var id = Guid.NewGuid();
            BoxUserProfile profile = new BoxUserProfile()
            {
                ProfileId = id,
                IdentitytId = id,
                Active = false
            };
            await _userRepository.AddNewUser(profile, model.Username, model.Password);
            return RedirectToAction("index", "home");
        }

        private async Task<bool> ResolveNewUserEmail(string email)
        {
            return await _userRepository.UserExistByEmail(email);
        }
    }
}