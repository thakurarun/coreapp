using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Entities;
using System;

namespace Database.Repository
{
    public interface IBoxUserRepository
    {
        Task<bool> UserExistByEmail(string email);
        Task<bool> AddNewUser(BoxUserProfile user, string username, string password);
        BoxUserProfile GetUser(Guid profileId);
        BoxUserProfile GetUserAuthentication(string username, string password);
        IEnumerable<BoxUserProfile> GetUsers();
    }
}