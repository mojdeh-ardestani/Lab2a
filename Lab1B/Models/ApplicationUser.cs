using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Lab1B.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
       
      
      public string LastName { get; set; }
      public string FirstName { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        [required]
        public DateTime BirthDate { get; set; }
    }
}
