using MVC_JSTC_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_JSTC.Models
{
    public class ProductsModel
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Product_Series { get; set; }
        public string Product_Model { get; set; }
        public System.DateTime Product_Model_Year { get; set; }
        public string Product_Series_Info { get; set; }
        public Nullable<bool> Product_Featured { get; set; }
        public string SubCategory { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
    }
}