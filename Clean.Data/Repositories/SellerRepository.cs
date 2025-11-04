using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanData.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DataContext _context;
        public SellerRepository(DataContext context)
        {
            _context = context;
        }
        public List<Seller> GetSellers()
        {
            return _context.sellers.ToList();
        }
        public Seller GetById(int id)
        {
            return _context.sellers.FirstOrDefault(s => s.Id == id);
        }

        public Seller Add(Seller seller)
        {
            _context.sellers.Add(seller);
            _context.SaveChanges();
            return seller;
        }

        public void Update(Seller seller)
        {
            var existingSeller = _context.sellers.FirstOrDefault(s => s.Id == seller.Id);
            if (existingSeller != null)
            {
                existingSeller.UserName = seller.UserName;
                existingSeller.CountrySeller = seller.CountrySeller;
                existingSeller.ShopName = seller.ShopName;
                
                // אם יש Password חדש, עדכן אותו
                if (!string.IsNullOrEmpty(seller.Password))
                {
                    existingSeller.Password = seller.Password;
                }
                
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var seller = GetById(id);
            if (seller != null)
            {
                _context.sellers.Remove(seller);
                _context.SaveChanges();
            }
        }

        public Seller GetByUsername(string username)
        {
            return _context.sellers.FirstOrDefault(s => s.UserName == username);
        }

    }
}
