using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MVC_JSTC_DAL;
using MVC_JSTC_Repository.Repositories;

namespace MVC_JSTC_Repository.Repository
{
    public interface IManufacturerRepository<T> : IRepository<tblManufacturer, int>
    {
    }
    public class ManufacturerRepository<T> : GenericRepository<tblManufacturer>, IManufacturerRepository<T>
    {
        public ManufacturerRepository(JusticeEntities _context) : base(_context)
        {
            this._context = _context;
        }

    }
}