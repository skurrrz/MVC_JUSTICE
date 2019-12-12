using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_JSTC.Models
{
    public class LoginModel

    {
        [StringLength(50, ErrorMessage = "Max length 50 characters")]
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "Max length 100 characters")]
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}