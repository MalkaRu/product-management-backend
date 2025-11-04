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
    public class SalesRepository : ISalesRepository
    {
        private readonly DataContext _context;
        public SalesRepository(DataContext context)
        {
            _context = context;
        }
        public List<Sales> GetSales()
        {
            return _context.sales.ToList();
        }
        public Sales GetById(int id)
        {
            return _context.sales.FirstOrDefault(s => s.Id == id);
        }
        public Sales Add(Sales sale)
        {
            if (sale.ProductIds != null && sale.ProductIds.Any())
            {
                var existingProductIds = _context.products
                    .Where(p => sale.ProductIds.Contains(p.Id))
                    .Select(p => p.Id)
                    .ToList();
                
                // שמור רק ProductIds שקיימים
                sale.ProductIds = existingProductIds;
            }
    
            _context.sales.Add(sale);
            _context.SaveChanges();
            return sale;
        }

        public void Update(Sales sale)
        {
            if (sale.ProductIds != null && sale.ProductIds.Any())
            {
                var existingProductIds = _context.products
                    .Where(p => sale.ProductIds.Contains(p.Id))
                    .Select(p => p.Id)
                    .ToList();
                
                sale.ProductIds = existingProductIds;
            }
            _context.sales.Update(sale);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sale = GetById(id);
            if (sale != null)
            {
                _context.sales.Remove(sale);
                _context.SaveChanges();
            }
        }
    }
}
