using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IBL _bl;
        public OrderController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public List<Order> Get(int id)
        // public ActionResult<Order> Get(int id)
        {
            return _bl.GetOrderByUserId(id);
            // Order foundUserOrder = _bl.GetOrderByUserId(id);
            // if(foundUserOrder.CustomerId != 0)
            // {
            //     return Ok(foundUserOrder);
            // }
            // else
            // {
            //     return NoContent();
            // }
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
