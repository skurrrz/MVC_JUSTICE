using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_JSTC.Models
{
    public class SearchModel

    {
        [Display(Name = "Search")]
        public string Input { get; set; }
    }
}