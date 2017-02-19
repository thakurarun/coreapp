using Database.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class BoxUserRepository : IBoxUserRepository
    {
        private BlueBoxContext _context;
        private UserManager<BoxIdentityUser> _userManager;

        public BoxUserRepository(BlueBoxContext context, UserManager<BoxIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region Authentication
        public async Task<bool> UserExistByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;
            return true;
        }

        public BoxUserProfile GetUserAuthentication(string username, string password)
        {
            //return _context.BoxUsers.FirstOrDefault(user =>
            //(user.Username == username || user.Email == username)
            //&& user.Password == password);
            return null;
        }
        #endregion

        #region Add or Update
        public async Task<bool> AddNewUser(BoxUserProfile user, string username, string password)
        {
            var boxUser = new BoxIdentityUser()
            {
                Email = username,
                UserName = username,
                IdentitytId = user.IdentitytId
            };
            var identity = await _userManager.CreateAsync(boxUser, password);
            if (identity.Succeeded)
            {
                await _context.BoxUserProfiles.AddAsync(user);
                await _context.SaveChangesAsync();
                return identity.Succeeded;
            }
            throw new Exception($"{nameof(AddNewUser)}:" +
                $" User identity not created");
        }
        #endregion

        #region Get
        public IEnumerable<BoxUserProfile> GetUsers()
        {
            return _context.BoxUserProfiles.ToList();
        }

        public BoxUserProfile GetUser(Guid profileId)
        {
            return _context.BoxUserProfiles.SingleOrDefault(user => user.ProfileId == profileId);
        }
        #endregion

    }
}
