using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Organization
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string Desription    { get; set; }
        public bool Active { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
