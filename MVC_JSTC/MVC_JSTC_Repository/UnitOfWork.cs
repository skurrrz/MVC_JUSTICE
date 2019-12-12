using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using MVC_JSTC_DAL;
using MVC_JSTC_Repository;
using MVC_JSTC_Repository.Repository;

namespace MVC_JSTC_DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly JusticeEntities _context = new JusticeEntities();
        private ManufacturerRepository<tblManufacturer> manufacturerRepository;
        private OrderRepository<tblOrder> orderRepository;
        private ProductsRepository<tblProduct> productRepository;
        private PropertyRepository<tblProperty> propertyRepository;
        private PropertyValuesRepository<tblPropertyValue> propertyValueRepository;
        private UserRepository<tblUser> userRepository;


        //Manufacturer
        public ManufacturerRepository<tblManufacturer> ManufacturerRepository
        {
            get
            {

                if (this.manufacturerRepository == null)
                {this.manufacturerRepository = new ManufacturerRepository<tblManufacturer>(_context);}
                return manufacturerRepository;
            }
        }

        //Order
        public OrderRepository<tblOrder> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {this.orderRepository = new OrderRepository<tblOrder>(_context);}
                return orderRepository;
            }
        }

        //Products
        public ProductsRepository<tblProduct> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {this.productRepository = new ProductsRepository<tblProduct>(_context);}
                return productRepository;
            }
        }

        //Property
        public PropertyRepository<tblProperty> PropertyRepository
        {
            get
            {
                if (this.propertyRepository == null)
                {this.propertyRepository = new PropertyRepository<tblProperty>(_context);}
                return propertyRepository;
            }
        }

        //PropertyValues
        public PropertyValuesRepository<tblPropertyValue> PropertyValuesRepository
        {
            get
            {
                if (this.propertyValueRepository == null)
                {this.propertyValueRepository = new PropertyValuesRepository<tblPropertyValue>(_context);}
                return propertyValueRepository;
            }
        }

        //User
        public UserRepository<tblUser> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {this.userRepository = new UserRepository<tblUser>(_context);}
                return userRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}