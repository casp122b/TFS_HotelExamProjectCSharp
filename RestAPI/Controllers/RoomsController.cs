using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<RoomBO> Get()
        {
            return facade.RoomService.GetAll();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Rooms
        [HttpPost]
        public IActionResult Post([FromBody]RoomBO roomBO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = facade.RoomService.Create(roomBO);
            return Ok(roomBO);
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
