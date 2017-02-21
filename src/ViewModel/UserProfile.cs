using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.ViewModel
{
    public class UserProfile
    {
        public Guid ProfileId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Contact number is required")]
        public string Contact { get; set; }
        public bool Active { get; set; }
    }
}
