﻿using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.ViewModels
{
    public class RegisterUserViewModel
    {   
        [Required, MaxLength(256)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
    }
}
