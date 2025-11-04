using Clean.Core.DTOs;
using Clean.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace CleanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SellersController : ControllerBase
    {
        private readonly SellerService _service;
        public SellersController(SellerService service)
        {
            _service = service;
        }
        // GET: api/<SellerController>
        [HttpGet]
        public ActionResult<List<SellerDto>> GetSellers()
        {
            return Ok(_service.GetSellers());
        }
        [HttpGet("{id}")]
        public ActionResult<SellerDto> GetById(int id)
        {
            var seller = _service.GetById(id);
            if (seller == null)
                return NotFound();
            return Ok(seller);
        }

        // POST לא זמין - רק דרך Register ב-AuthController

        // PUT api/<SellerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SellerDto sellerDto)
        {
            sellerDto.Id = id;
            _service.Update(sellerDto);   
        }

        // PUT api/<SellerController>/5/full - עדכון עם סיסמה
        [HttpPut("{id}/full")]
        public void PutWithPassword(int id, [FromBody] SellerAuthDto sellerDto)
        {
            sellerDto.Id = id;
            _service.UpdateWithPassword(sellerDto);
        }

        // DELETE api/<SellerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }


    }
}
