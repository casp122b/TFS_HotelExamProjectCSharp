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
    public class SuitesController: Controller
    {
        IBLLFacade facade;

        public SuitesController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/Suites
        // GET all suites
        [HttpGet]
        public IEnumerable<SuiteBO> Get() => facade.SuiteService.GetAll();

        // GET: api/Suites/id
        // GET one suite by it's id
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public SuiteBO Get(int id)
        {
            return facade.SuiteService.Get(id);
        }

        // POST: api/Suites
        // POST (Create) one suite
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody]SuiteBO suiteBO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(facade.SuiteService.Create(suiteBO));
        }

        // PUT: api/Suites/id
        // PUT (Update) one suite
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SuiteBO suiteBO)
        {
            if (id != suiteBO.Id)
            {
                return StatusCode(405, "Path Id does not match Room Id in json object");
            }

            try
            {
                var suiteUpdated = facade.SuiteService.Update(suiteBO);
                return Ok(suiteUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/Suites/id
        // DELETE one suite by it's id
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var suiteDelete = facade.SuiteService.Delete(id);
                return Ok(suiteDelete);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}