using Microsoft.AspNetCore.Mvc;
using Clean.Core.DTOs;
using Clean.Service;
using Microsoft.AspNetCore.Authorization;


namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _service;
        public ClientController(ClientService service)
        {
            _service = service;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult<List<ClientDto>> GetClients()
        {
            return Ok(_service.GetClients());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetById(int id)
        {
            var client = _service.GetById(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost] //הוספה
        public ActionResult<ClientDto> Post(ClientDto clientDto)
        {
            //validation
            clientDto.Id = 0;
            var newClient = _service.Add(clientDto);
            return Ok(newClient);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClientDto clientDto)
        {
            clientDto.Id = id;
            _service.Update(clientDto);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
