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

namespace src.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Profile")]
    public class ProfileController : Controller
    {
        private IBoxUserRepository _userRepository;

        public ProfileController(IBoxUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var boxProfile = _userRepository.GetProfileByEmail("arun@mail.com");
            var profile = Mapper.Map<UserProfile>(boxProfile);
            return Ok(profile);
        }
    }
}