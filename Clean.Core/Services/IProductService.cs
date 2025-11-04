using Clean.Core.Entities;
using Clean.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductDto GetById(int id);
        ProductDto Add(ProductDto productDto);
        void Update(ProductDto productDto);
        void Delete(int id);
    }

}
