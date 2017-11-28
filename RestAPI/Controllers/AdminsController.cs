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
    public class AdminsController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/values
        [HttpGet]
        public IEnumerable<AdminBO> Get()
        {
            return facade.AdminService.GetAll();
        }

        // GET
        [HttpGet("{id}")]
        public AdminBO Get(int id)
        {
            return facade.AdminService.Get(id);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody]AdminBO admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.AdminService.Create(admin));
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AdminBO admin)
        {
            if (id != admin.Id)
            {
                return StatusCode(405, "Path Id does not match Admin Id in json object");
            }
            try
            {
                var adminUpdated = facade.AdminService.Update(admin);
                return Ok(adminUpdated);
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
                var adminDelete = facade.AdminService.Delete(id);
                return Ok(adminDelete);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}