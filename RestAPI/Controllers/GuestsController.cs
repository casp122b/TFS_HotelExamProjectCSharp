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
    public class GuestsController: Controller
    {
        IBLLFacade facade;

        public GuestsController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/Guests
        // GET all guests
        //[Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<GuestBO> Get() => facade.GuestService.GetAll();

        // GET: api/Guests/id
        // GET one guest by it's id
        [HttpGet("{id}")]
        public GuestBO Get(int id) => facade.GuestService.Get(id);

        // POST: api/Guests
        // POST (Create) one guest
        [HttpPost]
        public IActionResult Post([FromBody]GuestBO guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(facade.GuestService.Create(guest));
        }

        // PUT: api/Guests/id
        // PUT (Update) one guest
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GuestBO guest)
        {
            if (id != guest.Id)
            {
                return StatusCode(405, "Path Id does not match Guest Id in json object");
            }

            try
            {
                var guestUpdated = facade.GuestService.Update(guest);
                return Ok(guestUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/Guests/id
        // DELETE one guest by it's id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var guestDelete = facade.GuestService.Delete(id);
                return Ok(guestDelete);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}