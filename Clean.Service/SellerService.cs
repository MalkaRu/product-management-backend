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
    public class SellerService:ISellerService
    {
        private readonly ISellerRepository _repository;
        private readonly IMapper _mapper;
        public SellerService(ISellerRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<SellerDto> GetSellers()
        {
            var s= _repository.GetSellers();
            return _mapper.Map<List<SellerDto>>(s);
        }
        public SellerDto GetById(int id)
        {
            var seller = _repository.GetById(id);
            return _mapper.Map<SellerDto>(seller);
        }

        public SellerAuthDto Add(SellerAuthDto sellerAuthDto)
        {
            var seller = _mapper.Map<Seller>(sellerAuthDto);
            var newSeller = _repository.Add(seller);
            return _mapper.Map<SellerAuthDto>(newSeller);
        }

        public void Update(SellerDto sellerDto)
        {
            var seller = _mapper.Map<Seller>(sellerDto);
            _repository.Update(seller);
        }

        public void UpdateWithPassword(SellerAuthDto sellerDto)
        {
            var seller = _mapper.Map<Seller>(sellerDto);
            _repository.Update(seller);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public SellerDto GetByUsername(string username)
        {
            var seller = _repository.GetByUsername(username);
            return _mapper.Map<SellerDto>(seller); // ללא Password
        }

        // פונקציות אימות
        public SellerAuthDto GetByUsernameForAuth(string username)
        {
            var seller = _repository.GetByUsername(username);
            return _mapper.Map<SellerAuthDto>(seller); // עם Password
        }

    }
}
