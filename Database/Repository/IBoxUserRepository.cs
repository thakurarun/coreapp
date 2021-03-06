﻿using System.Collections.Generic;
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
        IEnumerable<BoxUserProfile> GetUsers();
        BoxUserProfile GetProfileByEmail(string email);
        bool SaveProfile(BoxUserProfile profile);
    }
}