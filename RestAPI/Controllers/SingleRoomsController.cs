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
    public class SingleRoomsController: Controller
    {
        IBLLFacade facade;

        public SingleRoomsController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/SingleRooms
        // GET all singlerooms
        [HttpGet]
        public IEnumerable<SingleRoomBO> Get() => facade.SingleRoomService.GetAll();

        // GET: api/SingleRooms/id
        // GET one singleroom by it's id
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public SingleRoomBO Get(int id) => facade.SingleRoomService.Get(id);

        // POST: api/SingleRooms
        // POST (Create) one singleroom
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody]SingleRoomBO singleRoomBO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(facade.SingleRoomService.Create(singleRoomBO));
        }

        // PUT: api/SingleRooms/id
        // PUT (Update) one singleroom
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SingleRoomBO singleRoomBO)
        {
            if (id != singleRoomBO.Id)
            {
                return StatusCode(405, "Path Id does not match Room Id in json object");
            }

            try
            {
                var singleRoomUpdated = facade.SingleRoomService.Update(singleRoomBO);
                return Ok(singleRoomUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/SingleRooms/id
        // DELETE one singleRoom by it's id
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var singleRoomDelete = facade.SingleRoomService.Delete(id);
                return Ok(singleRoomDelete);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}