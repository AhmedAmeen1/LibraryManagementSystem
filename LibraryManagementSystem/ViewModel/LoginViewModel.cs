﻿using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User name is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }




        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }




        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
