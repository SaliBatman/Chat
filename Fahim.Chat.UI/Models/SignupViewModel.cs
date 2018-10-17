﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fahim.Chat.UI.Models
{
    public class SignupViewModel
    {
        [Required]
        public string Firstname { get; set; }
        [Required]

        public string Lastname { get; set; }
        [Required]

        public string Password { get; set; }

        public string Email { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
    }
}
