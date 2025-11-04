using AutoMapper;
using Clean.Core.DTOs;
using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clean.Service
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _repository;
        private readonly IMapper _mapper;

        public SalesService(ISalesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<SaleDto> GetSales()
        {
            var sales = _repository.GetSales();
            return _mapper.Map<List<SaleDto>>(sales);
        }

        public SaleDto GetById(int id)
        {
            var sale = _repository.GetById(id);
            return _mapper.Map<SaleDto>(sale);
        }

        public SaleDto Add(SaleDto saleDto)
        {
            var sale = _mapper.Map<Sales>(saleDto);
            var newSale = _repository.Add(sale);
            return _mapper.Map<SaleDto>(newSale);
        }

        public void Update(SaleDto saleDto)
        {
            var sale = _mapper.Map<Sales>(saleDto);
            _repository.Update(sale);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
