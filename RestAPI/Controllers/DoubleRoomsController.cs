using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DoubleRoomsController: Controller
    {
        IBLLFacade facade;

        public DoubleRoomsController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/DoubleRooms
        // GET all doublerooms
        [HttpGet]
        public IEnumerable<DoubleRoomBO> Get() => facade.DoubleRoomService.GetAll();

        // GET: api/DoubleRooms/id
        // GET one doubleroom by it's id
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public DoubleRoomBO Get(int id) => facade.DoubleRoomService.Get(id);

        // POST: api/DoubleRooms
        // POST (Create) one doubleroom
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody]DoubleRoomBO doubleRoomBO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(facade.DoubleRoomService.Create(doubleRoomBO));
        }

        // PUT: api/DoubleRooms/id
        // PUT (Update) one doubleroom
        [Authorize(Roles = "Administrator")]
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

        // DELETE: api/DoubleRooms/id
        // DELETE one doubleroom by it's id
        [Authorize(Roles = "Administrator")]
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