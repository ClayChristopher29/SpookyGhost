using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghost.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string NewUserName { get; set; }
        public List<Investigation> Investigations { get; set; } = new List<Investigation>();
    }
}
