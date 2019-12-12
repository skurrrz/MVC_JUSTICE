using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MVC_JSTC_DAL;
using MVC_JSTC_Repository.Repositories;


namespace MVC_JSTC_Repository.Repository
{
    public interface IPropertyRepository<T> : IRepository<tblProperty, int>
    {
    }

    public class PropertyRepository<T> : GenericRepository<tblProperty>, IPropertyRepository<T>
    {
        public PropertyRepository(JusticeEntities _context) : base(_context)
        {
            this._context = _context;
        }

    }
}