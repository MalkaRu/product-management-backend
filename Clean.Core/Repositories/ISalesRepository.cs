using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Repositories
{
    public interface ISalesRepository
    {
        List<Sales> GetSales();
        Sales GetById(int id);
        Sales Add(Sales sale);
        void Update(Sales sale);
        void Delete(int id);
    }

}
