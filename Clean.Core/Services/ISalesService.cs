using Clean.Core.Entities;
using Clean.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public interface ISalesService
    {
        List<SaleDto> GetSales();
        SaleDto GetById(int id);
        SaleDto Add(SaleDto saleDto);
        void Update(SaleDto saleDto);
        void Delete(int id);
    }
}
