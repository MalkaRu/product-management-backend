using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Repositories
{
    public interface ISellerRepository
    {
        List<Seller> GetSellers();
        Seller GetById(int id);
        Seller Add(Seller seller);
        void Update(Seller seller);
        void Delete(int id);
        Seller GetByUsername(string username);
    }
}
