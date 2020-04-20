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
        public PlayerAddFormViewModel()
        {

        }

        public PlayerAddFormViewModel(string email)
        {
            this.Email = email;
        }

        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare("Password"), Display(Name = "Confirm Password"), Required]
        public string ConfirmPassword { get; set; }

        public IFormFile PlayerImage { get; set; }
    }
}
