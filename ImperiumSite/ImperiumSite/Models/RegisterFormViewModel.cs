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
        public string Email { get; set; }

        public string message { get; set; }
    }
}
