using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1A.Models
{
    public class Member
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Key, Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string BirthDate { get; set; }
    }
}
