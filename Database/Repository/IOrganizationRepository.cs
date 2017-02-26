using Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public interface IOrganizationRepository
    {
        Task<Organization> GetOrganization(Guid OrganizationId);
    }
}
