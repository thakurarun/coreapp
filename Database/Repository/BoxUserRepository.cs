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
                user.CreationDate = DateTime.UtcNow;
                user.Organization = new Organization
                {
                    Active = false,
                    OrganizationId = Guid.NewGuid()
                };
                await _context.Organizations.AddAsync(user.Organization);
                await _context.BoxUserProfiles.AddAsync(user);
                try
                {
                    await _context.SaveChangesAsync();
                    return identity.Succeeded;
                }
                catch
                {
                    var deleteUser = await _userManager.FindByEmailAsync(boxUser.Email);
                    await _userManager.DeleteAsync(deleteUser);
                }
            }
            throw new Exception($"{nameof(AddNewUser)}:" +
                $" User identity not created");
        }

        public bool SaveProfile(BoxUserProfile profile)
        {
            var data = _context.BoxUserProfiles.FirstOrDefault(_profile => _profile.ProfileId == profile.ProfileId);
            if (data != null)
            {
                data.FirstName = profile.FirstName;
                data.LastName = profile.LastName;
                data.Contact = profile.Contact;
                data.Active = true;
                data.ModifiedDate = DateTime.UtcNow;
                _context.Update(data);
            }
            _context.SaveChanges();
            return true;
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

        public BoxUserProfile GetProfileByEmail(string email)
        {
            var result = (from idendity in _context.BoxIdentityUsers
                          join profile in _context.BoxUserProfiles on idendity.IdentitytId equals profile.IdentitytId
                          where idendity.Email == email
                          select profile).FirstOrDefault();
            return result;
        }

        #endregion

    }
}
