using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Database.Repository;
using AutoMapper;
using src.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Database.Entities;

namespace src.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Profile")]
    [Authorize]
    public class ProfileController : Controller
    {
        private IBoxUserRepository _userRepository;

        public ProfileController(IBoxUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var boxProfile = _userRepository.GetProfileByEmail(User.Identity.Name);
            var profile = Mapper.Map<UserProfileDTO>(boxProfile);
            return Ok(profile);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserProfileDTO data)
        {
            if (ModelState.IsValid)
            {
                var profile = Mapper.Map<BoxUserProfile>(data);
                _userRepository.SaveProfile(profile);
                return Ok(profile);
            }
            else
            {
                ModelState.AddModelError("", "Please enter correct data.");
            }

            return BadRequest(ModelState);
        }
    }
}