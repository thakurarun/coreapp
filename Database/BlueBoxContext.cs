using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Database.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Database
{
      public class BlueBoxContext : IdentityDbContext<BoxIdentityUser>
    {
        private IConfigurationRoot _config;
        
        public BlueBoxContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<BoxUserProfile> BoxUserProfiles { get; set; }
        public DbSet<BoxIdentityUser> BoxIdentityUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // dotnet ef --startup-project ../src migrations add InitialDatabase ----create migration. . .
            // dotnet ef --startup-project ../src database update  ---- update schema to database
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:MyApplicationContextConnection"],
               b => b.MigrationsAssembly("Database"));
        }
    }
}
