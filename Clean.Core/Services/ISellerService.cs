using Clean.Core.Entities;
using Clean.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public interface ISellerService
    {
        List<SellerDto> GetSellers();
        SellerDto GetById(int id);
        SellerAuthDto Add(SellerAuthDto sellerAuthDto); // רק דרך Register
        void Update(SellerDto sellerDto);
        void Delete(int id);
        SellerDto GetByUsername(string username);
        
        // פונקציות אימות
        SellerAuthDto GetByUsernameForAuth(string username);
    }
}
