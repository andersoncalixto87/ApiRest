using System;
using System.Collections.Generic;
using System.Linq;
using MinhaPrimeiraApi.Entities;
using MinhaPrimeiraApi.Exceptions;
using MinhaPrimeiraApi.Interfaces;

namespace MinhaPrimeiraApi.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiRestContext _apiRestContext;
        public ProductRepository(ApiRestContext apiRestContext)
        {
            _apiRestContext = apiRestContext;
        }
        public void Add(Product product)
        {
            try
            {
                _apiRestContext.Set<Product>().Add(product);
                _apiRestContext.SaveChanges();
            }
            catch (CustomException ex )
            {                
                throw ex;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _apiRestContext.Set<Product>().ToList();
        }

        public Product GetById(int id)
        {
            return _apiRestContext.Set<Product>().Find(id);
        }

        public void Remove(Product product)
        {
            try
            {
                _apiRestContext.Set<Product>().Remove(product);
                _apiRestContext.SaveChanges();
            }
            catch (CustomException ex )
            {                
                throw ex;
            }
        }

        public void Update(Product product)
        {
            try
            {
                _apiRestContext.Set<Product>().Update(product);
                _apiRestContext.SaveChanges();
            }
            catch (CustomException ex)
            {                
                throw ex;
            }
        }
    }
}