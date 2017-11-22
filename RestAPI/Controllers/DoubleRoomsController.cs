using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BLL;
using BLL.BusinessObjects;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DoubleRoomsController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/DoubleRooms
        [HttpGet]
        public IEnumerable<DoubleRoomBO> Get()
        {
            return facade.DoubleRoomService.GetAll();
        }

        // GET: api/DoubleRooms/5
        [HttpGet("{id}")]
        public DoubleRoomBO Get(int id)
        {
            return facade.DoubleRoomService.Get(id);
        }

        // POST: api/DoubleRooms
        [HttpPost]
        public IActionResult Post([FromBody]DoubleRoomBO doubleRoomBO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.DoubleRoomService.Create(doubleRoomBO));
        }

        // PUT: api/DoubleRooms/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DoubleRoomBO doubleRoomBO)
        {
            if (id != doubleRoomBO.Id)
            {
                return StatusCode(405, "Path Id does not match Room Id in json object");
            }
            try
            {
                var doubleRoomUpdated = facade.DoubleRoomService.Update(doubleRoomBO);
                return Ok(doubleRoomUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/DoubleRooms/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var doubleRoomDelete = facade.DoubleRoomService.Delete(id);
                return Ok(doubleRoomDelete);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}