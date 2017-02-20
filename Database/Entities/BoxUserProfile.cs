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
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Contact number is required")]
        public string Contact { get; set; }
        public Guid ProfileId { get; set; }
        public bool Active { get; set; }


        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
