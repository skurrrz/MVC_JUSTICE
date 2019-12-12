using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_JSTC.Models
{
    public class AuthenticationModel
    {
            public LoginModel Login { get; set; }
            public RegisterModel Register { get; set; }
    }
}