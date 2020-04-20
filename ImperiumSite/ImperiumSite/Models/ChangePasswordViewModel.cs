using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumSite.Models
{
    public class ChangePasswordViewModel
    {
        public ChangePasswordViewModel()
        {

        }

        public string Email { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password"), Display(Name = "Confirm New Password")]
        public string ConfirmPassword { get; set; }
    }
}
