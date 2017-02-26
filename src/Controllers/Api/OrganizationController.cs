using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Database.Repository;

namespace src.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/org")]
    [Authorize]
    public class OrganizationController : Controller
    {
        private IBoxUserRepository _userRepository;
        private IOrganizationRepository _organizationRepository;

        public OrganizationController(IBoxUserRepository userRepository, IOrganizationRepository organizationRepository)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = _userRepository.GetProfileByEmail(User.Identity.Name);
            var org = await _organizationRepository.GetOrganization(user.OrganizationId);
            return Ok(org);
        }
    }
}