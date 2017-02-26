using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities
{
    public class BoxUserProfile
    {
        public Guid Id { get; set; }
        public Guid IdentitytId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }

        public Guid ProfileId { get; set; }
        public bool Active { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
