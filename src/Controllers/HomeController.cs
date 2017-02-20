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
    public class HomeController : Controller
    {
        private SignInManager<BoxIdentityUser> _signInMnager;
        private IBoxUserRepository _userRepository;

        public HomeController(SignInManager<BoxIdentityUser> signInMnager, IBoxUserRepository userRepository)
        {
            _signInMnager = signInMnager;
            _userRepository = userRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            BoxUserProfile profile = _userRepository.GetProfileByEmail(User.Identity.Name);
            if (!profile.Active)
                return View(profile);
            else
                return View(profile);
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
            return View("Index");
        }
    }
}
