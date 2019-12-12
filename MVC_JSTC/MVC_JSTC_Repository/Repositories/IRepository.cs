using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MVC_JSTC_DAL;
using MVC_JSTC_Repository.Repositories;
using System.Linq.Expressions;

namespace MVC_JSTC_Repository.Repositories
{
    //The Generic Interface Repository for Performing Read/Add/Delete operations
    public interface IRepository<T, in TPk> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}