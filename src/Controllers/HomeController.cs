using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Database.Entities;
using Database.Repository;

namespace src.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private SignInManager<BoxIdentityUser> _signInMnager;
        private IBoxUserRepository _userRepository;

        public HomeController(SignInManager<BoxIdentityUser> signInMnager, IBoxUserRepository userRepository)
        {
            _signInMnager = signInMnager;
            _userRepository = userRepository;
        }
        
        public IActionResult Index()
        {
            BoxUserProfile profile = _userRepository.GetProfileByEmail(User.Identity.Name);
            if (!profile.Active)
                return View(profile);
            else
                return View(profile);
        }

        public IActionResult EditProfile()
        {
            BoxUserProfile profile = _userRepository.GetProfileByEmail(User.Identity.Name);
            return View("EditProfile", profile);
        }

        [HttpPost]
        public IActionResult SaveProfile(BoxUserProfile model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.SaveProfile(model);
            }
            else
            {
                ModelState.AddModelError("", "Some fields are missing");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
