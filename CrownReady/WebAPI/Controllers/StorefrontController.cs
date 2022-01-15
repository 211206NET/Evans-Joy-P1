using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreFrontController : ControllerBase
    {
        private IBL _bl;
        public StoreFrontController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<StoreFrontController>
        [HttpGet]
        public List<StoreFront> Get()
        {
            return _bl.GetAllStoreFronts();
        }

        // GET api/<StoreFrontController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StoreFrontController>
        [HttpPost]
        public ActionResult Post([FromBody] StoreFront storeFrontToAdd)
        {
            try
            {
                _bl.AddStoreFront(storeFrontToAdd);
                return Created("Successfully add", storeFrontToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/<StoreFrontController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreFrontController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
