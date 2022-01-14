using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorefrontController : ControllerBase
    {
        // GET: api/<StorefrontController>
        [HttpGet]
        public List<StoreFront> Get()
        {
            return new List<StoreFront>(){
                new StoreFront() 
                { 
                    Name = "CrownReady - Pearland",
                    Address = "random address",
                    City = "Pearland",
                    State = "TX"
                },
                new StoreFront()
                {
                    Name = "CrownReady - Sugar Land",
                    Address = "random address",
                    City = "Sugar Land",
                    State = "TX"
                }
            };
        }

        // GET api/<StorefrontController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StorefrontController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StorefrontController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StorefrontController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
