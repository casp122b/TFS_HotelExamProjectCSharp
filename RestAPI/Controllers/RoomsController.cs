using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Rooms")]
    public class RoomsController : Controller
    {
        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rooms/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Rooms
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
