using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MVC_JSTC.Models
{
    public class MasterProductsModel
    {
        public SearchModel Search { get; set; }
        public FilterProductsModel Filter { get; set; }
        public ProductsModel Products { get; set; }
    }
}