using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System;
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

            facade.RoomService.Create(roomBO);
            Console.WriteLine("Controller" + " " + roomBO);
            return Ok(roomBO);
        }
        
        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RoomBO roomBO)
        {
            if (id != roomBO.Id)
            {
                return BadRequest("This is bad");
            }

            facade.RoomService.Update(roomBO);
            return Ok(roomBO);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
