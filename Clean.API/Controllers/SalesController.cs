using Clean.Core.DTOs;
using Clean.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace CleanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly SalesService _service;
        public SalesController(SalesService service)
        {
            _service = service;
        }

        // GET: api/<SalesController>
        [HttpGet]
        public ActionResult<List<SaleDto>> GetSales()
        {
            return Ok(_service.GetSales());
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public ActionResult<SaleDto> GetById(int id)
        {
            var sale = _service.GetById(id);
            if (sale == null)
                return NotFound();
            return Ok(sale);
        }

        // POST api/<SalesController>
        [HttpPost] //הוספה
        public ActionResult<SaleDto> Post(SaleDto saleDto)
        {
            saleDto.Id = 0; // אפס את ה-Id לפני השליחה לשירות
            //validation
            var newSale = _service.Add(saleDto);
            return Ok(newSale);
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SaleDto saleDto)
        {
            saleDto.Id = id;
            _service.Update(saleDto);
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
