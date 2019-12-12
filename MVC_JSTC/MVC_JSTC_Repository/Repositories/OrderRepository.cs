using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MVC_JSTC_DAL;
using MVC_JSTC_Repository.Repositories;

namespace MVC_JSTC_Repository.Repository
{
    public interface IOrderRepository<T> : IRepository<tblOrder, int>
    {
    }
    public class OrderRepository<T> : GenericRepository<tblOrder>, IOrderRepository<T>
    {
        public OrderRepository(JusticeEntities _context) : base(_context)
        {
            this._context = _context;
        }
    }
}