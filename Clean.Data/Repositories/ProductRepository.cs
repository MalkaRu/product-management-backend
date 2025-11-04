using Clean.Core.Entities;
using Clean.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.products.ToList();
        }
        public Product GetById(int id)
        {
            return _context.products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Update(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetBySellerId(int sellerId)
        {
            return _context.products.Where(p => p.SellerId == sellerId).ToList();
        }
    }
}
