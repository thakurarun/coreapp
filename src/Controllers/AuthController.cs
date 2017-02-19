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

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            return View(model);
        }

        public IActionResult Register()
        {
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
                        return RedirectToAction(returnUrl);
                    }
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("InvalidCredential", "Username or password is incorrect");
                }
            }
            else
            {
                ModelState.AddModelError("ModelInvalid", "Some field are incorrect.");
            }
            return View("Index", model);
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNew(LoginModel model)
        {
            var id = Guid.NewGuid();
            BoxUserProfile profile = new BoxUserProfile()
            {
                ProfileId = id,
                IdentitytId = id,
                Active = false
            };
            await _userRepository.AddNewUser(profile, model.Username, model.Password);
            return View("Index");
        }
    }
}