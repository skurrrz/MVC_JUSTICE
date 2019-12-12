using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MVC_JSTC_DAL;
using MVC_JSTC_Repository.Repositories;
using System.Data.Entity.SqlServer;

namespace MVC_JSTC_Repository.Repository
{
    public interface IProductsRepository<T> : IRepository<tblProduct, int>
    {
    }
    public class ProductsRepository<T> : GenericRepository<tblProduct>, IProductsRepository<T>
    {
        public ProductsRepository(JusticeEntities _context) : base(_context)
        {
            this._context = _context;
        }

        public IEnumerable<tblProduct> GetAllProducts()
        {
            //Returns all products
            List<tblProduct> dispProducts = _context.tblProducts.ToList();
            return dispProducts;
        }

        public IEnumerable<tblProduct> GetProductsByKey(string key)
        {
            IEnumerable<tblProduct> searchRes;
            searchRes = _context.tblProducts
                .Where(p => 
                SqlFunctions.PatIndex("%" + key + "%", p.Product_Name) > 0 ||
                SqlFunctions.PatIndex("%" + key + "%", p.Product_Series) > 0 ||
                SqlFunctions.PatIndex("%" + key + "%", p.Product_Model) > 0 ||
                SqlFunctions.PatIndex("%" + key + "%", p.Product_Series_Info) > 0 ||
                SqlFunctions.PatIndex("%" + key + "%", p.Category) > 0 ||
                SqlFunctions.PatIndex("%" + key + "%", p.SubCategory) > 0 ||
                SqlFunctions.PatIndex("%" + key + "%", p.Manufacturer) > 0)
                .ToList();
            return searchRes;
        }

        public IEnumerable<tblProduct> GetProductsByCategory(string keyCat, string keySubCat)
        {
            IEnumerable<tblProduct> searchRes;
            searchRes = _context.tblProducts
                .Where(p =>
                SqlFunctions.PatIndex("%" + keyCat + "%", p.Category) > 0 &&
                SqlFunctions.PatIndex("%" + keySubCat + "%", p.SubCategory) > 0)
                .ToList();
            return searchRes;
        }

        public IEnumerable<tblProduct> GetProductsToCompare(int choice1, int choice2, int choice3)
        {
            IEnumerable<tblProduct> searchRes;

            //3rd box was not checked
            if (choice3 != 0) {
                searchRes = _context.tblProducts.Where(p=>
                    p.Product_Id == choice1 ||
                    p.Product_Id == choice2 ||
                    p.Product_Id == choice3)
                    .ToList();
            }

            //2nd box was not checked
            else if (choice2 != 0) {
                 searchRes = _context.tblProducts.Where(p=>
                    p.Product_Id == choice1 ||
                    p.Product_Id == choice2)
                    .ToList();
            }

            //no boxes were checked
            else {
                searchRes = _context.tblProducts.Where(p =>
                    p.Product_Id == choice1)
                    .ToList();
            }
            return searchRes;
        }
        public IEnumerable<tblProduct> GetProductRequested(int id)
        {
            IEnumerable<tblProduct> searchRes;
            searchRes = _context.tblProducts.Where(p =>
                    p.Product_Id == id)
                    .ToList();
            return searchRes;
        }
    }
}