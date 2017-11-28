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
    public class BookingsController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/values
        [HttpGet]
        public IEnumerable<BookingBO> Get()
        {
            return facade.BookingService.GetAll();
        }

        // GET
        [HttpGet("{id}")]
        public BookingBO Get(int id)
        {
            return facade.BookingService.Get(id);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody]BookingBO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.BookingService.Create(book));
        }

        // PUT
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

        // DELETE
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