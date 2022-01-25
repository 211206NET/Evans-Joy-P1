using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBL _bl;
        public UserController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            return _bl.GetAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{name}")]
        public ActionResult<User> Get(string name)
        {
            User foundUser = _bl.GetUserByName(name);
            if (foundUser.Name != null)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public List<Order> Get(int id)
        {
            return _bl.GetOrderByUserId(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User userToAdd)
        {
            _bl.AddUser(userToAdd);
            return Created("Successfully add", userToAdd);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
