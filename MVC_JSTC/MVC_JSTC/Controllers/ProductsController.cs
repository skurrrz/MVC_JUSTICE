
using MVC_JSTC.Models;
using MVC_JSTC_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVC_JSTC_Service;

namespace MVC_JSTC.Controllers
{
    public class ProductsController : Controller
    {
        Service service = new Service();
        public string totalFilterStr = "";

        /****************** DEFAULT ACTION ************************/
        public ActionResult ProductsIndex()
        {
            if (Session["User"] != null)
            {
                return View();
            }

            else
            {
                return JavaScript("window.location.href = '/Home/Index'");
            }

        }


        /****************** RENDER SEARCH BAR ************************/
        [HttpGet]
        public ActionResult Search()
        {
            return PartialView("_SearchPartial");
        }


        /****************** HTTPPOST SEARCHBAR ACTION  ************************/
        [HttpPost]
        public ActionResult Search(string query)
        {
            IEnumerable<tblProduct> result = service.SearchProductsByKey(query);

            //return model
            return PartialView("_ProductsPartial", result);
        }


        /****************** RENDER FILTER SIDEBAR ************************/
        [HttpGet]
        public ActionResult Filter()
        {
            return PartialView("_FilterPartial");
        }


        /****************** HTTPPOST FILTER ACTION  ************************/
        [HttpPost]
        public ActionResult Filter(string filterBtn)
        {
            //separate string into two keys
            string keyCat = service.getCat(filterBtn);
            string keySubCat = service.getSubCat(filterBtn);

            //Use Service to search for keywords
            IEnumerable<tblProduct> result = service.SearchProductsByCategory(keyCat, keySubCat);

            //return model
            return PartialView("_ProductsPartial", result);
        }


        /****************** HTTPPOST COMPARE ACTION  ************************/
        [HttpPost]
        public ActionResult Compare(int choice1, int choice2, int choice3)
        {
            IEnumerable<tblProduct> result = service.SearchProductsToCompare(choice1, choice2, choice3);

            //return list of 1, 2, or 3 items with matching product_IDs
            return PartialView("_ProdComparePartial", result);
        }


        /****************** HTTPPOST GET ALL PRODUCTS ACTION  ************************/
        [HttpPost]
        public ActionResult GetAllProducts()
        {
            IEnumerable<tblProduct> result = service.SearchAllProducts();

            return PartialView("_ProductsPartial", result);
        }


        /****************** HTTPPOST DISPLAY SINGLE PRODUCT ACTION  ************************/
        [HttpPost]
        public ActionResult DisplayProduct(int btnSeeMore)
        {
            IEnumerable<tblProduct> result = service.SearchForProduct(btnSeeMore);

            return PartialView("_SingleProductPartial", result);
        }
    }
}