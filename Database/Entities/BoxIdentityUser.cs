using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class BoxIdentityUser : IdentityUser
    {
        public Guid IdentitytId { get; set; }
    }
}
