using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_JSTC.Models
{
    public class RegisterModel
    {
        [StringLength(50, ErrorMessage = "Max length 50 characters")]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "Max length 100 characters")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Max length 100 characters")]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Max length 100 characters")]
        [Compare("Password",
            ErrorMessage = "Passwords do not match")]
        public string Password_Comp { get; set; }

        //add option to upload picture
    }
}