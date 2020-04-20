﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperiumSite.Models
{
    public class RegisterAddViewModel
    {
        public RegisterAddViewModel()
        {
            TOKENEXPIRY = DateTime.Now;
        }

        public RegisterAddViewModel(RegisterFormViewModel register)
        {
            this.EMAIL = register.Email;
            this.TOKEN = GenerateToken();
            this.TOKENEXPIRY = DateTime.Now.AddHours(24);
            this.VERIFIED = false;
        }

        public string EMAIL { get; set; }

        public string TOKEN { get; set; }

        public DateTime TOKENEXPIRY { get; set; }

        public bool VERIFIED { get; set; }

        public string GenerateToken() 
        {
            int length = 100;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;  

              for (int i = 0; i < length; i++)
              {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);  
              }

            return str_build.ToString();
        }

    }
}
