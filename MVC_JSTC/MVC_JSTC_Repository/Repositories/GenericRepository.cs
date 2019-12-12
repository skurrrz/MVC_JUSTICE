using System;
using System.Web;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MVC_JSTC_DAL;
using MVC_JSTC_Repository.Repositories;

namespace MVC_JSTC_Repository
{
    public class GenericRepository<T> : IRepository<T, int> where T : class
    {
        //Declaration of database context and entity set
        internal JusticeEntities _context;
        internal DbSet<T> dbSet;

        //Constructor - accepts context instance and initializes entity set
        public GenericRepository(JusticeEntities _context)
        {
            this._context = _context;
            this.dbSet = _context.Set<T>();
        }

        /*************** CRUD  *******************/
        //GET METHOD
        //EX. GetAll(student => student.LastName == "Smith")
        //EX. Get(q => q.OrderBy(s => s.LastName))
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            //Applies filter expression if there is one (from Get)
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Parses expression
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            //Applies orderBy if it was added
            if (orderBy != null)
            {
                //returns ordered results from query
                return orderBy(query).ToList();
            }
            else
            {
                //returned unordered results from query
                return query.ToList();
            }
        }

        //INSERT METHOD
        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        //(Overload 1) DELETE VIA ID
        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        //(overload 2) DELETE GIVEN ITEM
        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        //UPDATE METHOD
        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}