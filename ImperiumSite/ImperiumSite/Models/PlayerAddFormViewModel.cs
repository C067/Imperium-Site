using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ImperiumSite.Models
{
    public class PlayerAddFormViewModel
    {
        public string numPattern = @"(?=.*\d)";
        public string lowerPattern = @"(?=.*[a-z])";
        public string upperPattern = @"(?=.*[A-Z])";
        public string specialPattern = @"(?!.*[&%$])";

        public PlayerAddFormViewModel()
        {

        }

        public PlayerAddFormViewModel(string email)
        {
            this.Email = email;
        }

        public string Email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Username must contain at least 3 characters"), MaxLength(25, ErrorMessage = "Username must not contain more than 25 characters")]
        public string Username { get; set; }

        [DataType(DataType.Password), Required]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters"), MaxLength(30, ErrorMessage = "Password must not contain more than 30 characters") ]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare("Password"), Display(Name = "Confirm Password"), Required]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters"), MaxLength(30, ErrorMessage = "Password must not contain more than 30 characters")]
        public string ConfirmPassword { get; set; }

        public IFormFile PlayerImage { get; set; }

        public List<string> PasswordErrorList { get; set; }
    }
}
