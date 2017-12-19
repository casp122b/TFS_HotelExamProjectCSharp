using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
    // Only administrators can use methods in this class.
    [Authorize(Roles = "Administrator")]
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdminsController: Controller
    {
        IBLLFacade facade;

        public AdminsController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/Admins
        // GET all admins
        [HttpGet]
        public IEnumerable<AdminBO> Get() => facade.AdminService.GetAll();

        // GET: api/Admins/id
        // GET one admin by it's id
        [HttpGet("{id}")]
        public AdminBO Get(int id) => facade.AdminService.Get(id);

        // POST: api/Admins
        // POST (Create) one admin
        [HttpPost]
        public IActionResult Post([FromBody]AdminBO admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(facade.AdminService.Create(admin));
        }

        // PUT: api/Admins/id
        // PUT (Update) one admin
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

        // DELETE: api/Admins/id
        // DELETE one admin by it's id
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