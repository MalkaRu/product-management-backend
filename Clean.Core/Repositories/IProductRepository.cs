using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Repositories
{
   public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetById(int id);
        Product Add(Product product);
        void Update(Product product);
        void Delete(int id);
        List<Product> GetBySellerId(int sellerId);
    }

}
