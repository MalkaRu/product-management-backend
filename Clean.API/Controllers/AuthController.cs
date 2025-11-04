using Clean.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean.Core.DTOs;
using System.Linq;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly SellerService _sellerService;

        public AuthController(JwtService jwtService, SellerService sellerService)
        {
            _jwtService = jwtService;
            _sellerService = sellerService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // חיפוש מוכר עם סיסמה
            var seller = _sellerService.GetByUsernameForAuth(login.Username);
            
            if (seller != null && seller.Password == login.Password)
            {
                var token = _jwtService.GenerateToken(seller.UserName);
                // מחזיר SellerDto ללא Password
                var userResponse = new SellerDto 
                {
                    Id = seller.Id,
                    UserName = seller.UserName,
                    CountrySeller = seller.CountrySeller,
                    ShopName = seller.ShopName
                };
                return Ok(new { Token = token.Token, User = userResponse });
            }
            
            return Unauthorized(new { Message = "שם משתמש או סיסמה שגויים" });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel register)
        {
            // בדיקה אם המשתמש כבר קיים
            var existingSeller = _sellerService.GetByUsernameForAuth(register.Username);
            if (existingSeller != null )
            {
                return BadRequest(new { Message = "שם המשתמש כבר קיים" });
            }

            // יצירת מוכר חדש עם סיסמה
            var newSeller = new SellerAuthDto
            {
                UserName = register.Username,
                Password = register.Password,
                CountrySeller = register.Country,
                ShopName = register.ShopName
            };

            var createdSeller = _sellerService.Add(newSeller);
            var token = _jwtService.GenerateToken(createdSeller.UserName);
            
            // מחזיר SellerDto ללא Password
            var userResponse = new SellerDto
            {
                Id = createdSeller.Id,
                UserName = createdSeller.UserName,
                CountrySeller = createdSeller.CountrySeller,
                ShopName = createdSeller.ShopName
            };
            
            return Ok(new { Token = token.Token, User = userResponse });
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string ShopName { get; set; }
    }
}
