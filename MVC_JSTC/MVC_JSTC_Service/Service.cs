using MVC_JSTC_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVC_JSTC_Repository.Repositories;

namespace MVC_JSTC_Service
{
    public class Service
    {
        //This attempts to log-in user, sends back result of attempt
        public string TryLogin(string user, string password)
        {
            var result = "";
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                result = unitOfWork.UserRepository.ValidateLogin(user, password);
            }
            return result;
        }

        //This attempts to create a new user account, sends back results of attempt
        public string TryCreateNewUser(string user, string email, string password )
        {
            var result = "";
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                result = unitOfWork.UserRepository.CreateNewUser(user, email, password);
            }
            return result;

        }

        //This returns a result set of entries that contain search value
        public IEnumerable<tblProduct> SearchAllProducts()
        {
            IEnumerable<tblProduct> result;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                result = unitOfWork.ProductRepository.GetAllProducts().ToList();
            }
            return result;

        }

        
        //This returns a result set of entries that contain search value
        public IEnumerable<tblProduct> SearchProductsByKey(string key)
        {
            IEnumerable<tblProduct> result;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                result = unitOfWork.ProductRepository.GetProductsByKey(key.ToLower()).ToList();
            }
            return result;

        }

        public IEnumerable<tblProduct> SearchProductsByCategory(string keyCat, string keySubCat)
        {
            IEnumerable<tblProduct> result;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                result = unitOfWork.ProductRepository.GetProductsByCategory(keyCat, keySubCat).ToList();
            }
            return result;

        }
        public string getCat(string categoryStr)
        {
            int index = categoryStr.IndexOf('-');
            string cat= categoryStr.Substring(0, index).Trim();
            System.Diagnostics.Debug.WriteLine("cat is: " + cat);
            return cat;
        }

        public string getSubCat(string categoryStr)
        {
            int index = categoryStr.IndexOf('-');
            string subcat =  categoryStr.Substring(index + 1).Trim();
            if (subcat == (-1).ToString()){ subcat = ""; }
            System.Diagnostics.Debug.WriteLine("subcat is: " + subcat);
            return subcat;
        }

        public IEnumerable<tblProduct> SearchProductsToCompare(int choice1, int choice2, int choice3)
        {
            IEnumerable<tblProduct> result;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                result = unitOfWork.ProductRepository.GetProductsToCompare(choice1, choice2, choice3).ToList();
            }
            return result;
        }

        public IEnumerable<tblProduct> SearchForProduct(int id)
        {
            IEnumerable<tblProduct> result;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                result = unitOfWork.ProductRepository.GetProductRequested(id).ToList();
            }
            return result;
        }


    }
}
