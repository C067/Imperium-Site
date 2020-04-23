using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumSite.Models
{
    public class RegisterFormViewModel
    {
        [Required]
        [MinLength(8, ErrorMessage = "Email must contain at least 8 characters"), MaxLength(50, ErrorMessage = "Email must not contain more than 50 characters")]
        public string Email { get; set; }

        public string message { get; set; }
    }
}
