using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logistics.Core.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDeliveryController : ControllerBase {
        // GET: api/<OrderDeliveryController>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderDeliveryController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<OrderDeliveryController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<OrderDeliveryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<OrderDeliveryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
