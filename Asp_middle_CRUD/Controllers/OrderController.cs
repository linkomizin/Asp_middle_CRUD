using Contarcts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp_middle_CRUD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IServicesManager _servicesManager;
        public OrderController(IServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }
        // GET:  <OrderController>/List
        [HttpGet("api/list")]
        public async Task<IActionResult> Get()
        {
            var list = await _servicesManager.OrderServices.GetAllAsync(new CancellationToken());
            return Ok(list);
        }

        [HttpGet("api/list")]
        public async Task<IActionResult> GetByFilter(DateTime leftDate, DateTime rightDate, string numberOrder, int providerId)
        {
            return Ok();
        }
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order =  await _servicesManager.OrderServices.GetByIdAsync(id, new CancellationToken());
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
