using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;
using Clean.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Clean.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<ProductDto> GetProducts()
        {
            var p= _repository.GetProducts();
            return _mapper.Map<List<ProductDto>>(p);
        }
        public ProductDto GetById(int id)
        {
            var product = _repository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto Add(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var newProduct = _repository.Add(product);
            return _mapper.Map<ProductDto>(newProduct);
        }

        public void Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Update(product);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ProductDto> GetBySellerId(int sellerId)
        {
            var products = _repository.GetBySellerId(sellerId);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
