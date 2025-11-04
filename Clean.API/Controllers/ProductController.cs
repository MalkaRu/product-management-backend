using Clean.Core.DTOs;
using Clean.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace CleanAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<ProductDto>> GetProducts()
        {
            return Ok(_service.GetProducts());
        }
         // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // GET api/<ProductController>/seller/5
        [HttpGet("seller/{sellerId}")]
        public ActionResult<List<ProductDto>> GetBySellerId(int sellerId)
        {
            var products = _service.GetBySellerId(sellerId);
            return Ok(products);
        }

        // POST api/<ProductController>
        [HttpPost] //הוספה
        public ActionResult<ProductDto> Post(ProductDto productDto)
        {
            productDto.Id = 0; // אפס את ה-Id לפני השליחה לשירות
            //validation
            var newProduct = _service.Add(productDto);
            return Ok(newProduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDto productDto)
        {
            productDto.Id = id;
            _service.Update(productDto);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
