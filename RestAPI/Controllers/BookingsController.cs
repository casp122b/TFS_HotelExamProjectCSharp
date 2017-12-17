using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookingsController: Controller
    {
        IBLLFacade facade;

        public BookingsController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/Bookings
        // GET all bookings
        [HttpGet]
        public IEnumerable<BookingBO> Get() => facade.BookingService.GetAll();

        // GET: api/Bookings/id
        // GET one booking by it's id
        [HttpGet("{id}")]
        public BookingBO Get(int id) => facade.BookingService.Get(id);

        // POST: api/Bookings
        // POST (Create) one booking
        [HttpPost]
        public IActionResult Post([FromBody]BookingBO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(facade.BookingService.Create(book));
        }

        // PUT: api/Bookings/id
        // PUT (Update) one booking
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookingBO book)
        {
            if (id != book.Id)
            {
                return StatusCode(405, "Path Id does not match Booking Id in json object");
            }

            try
            {
                var bookUpdated = facade.BookingService.Update(book);
                return Ok(bookUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/Bookings/id
        // DELETE one booking by it's id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var bookDelete = facade.BookingService.Delete(id);
                return Ok(bookDelete);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}