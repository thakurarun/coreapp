using Database.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private UserManager<BoxIdentityUser> _userManager;
        private BlueBoxContext _context;

        public OrganizationRepository(BlueBoxContext context, UserManager<BoxIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Organization> GetOrganization(Guid OrganizationId)
        {
            return await Task.Run(() =>
            {
                return _context.Organizations.FirstOrDefault(org => org.OrganizationId == OrganizationId);
            });
        }
    }
}
