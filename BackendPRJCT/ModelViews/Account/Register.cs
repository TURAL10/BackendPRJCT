﻿using System.ComponentModel.DataAnnotations;

namespace BackendPRJCT.ModelViews.Account
{
    public class Register
    {
        [Required, StringLength(50)]
        public string FullName { get; set; }
        [Required, StringLength(50)]
        public string UserName { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
