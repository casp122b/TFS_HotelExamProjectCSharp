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
    public class SuitesController : Controller
    {
        IBLLFacade facade;

        public SuitesController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/Suites
        [HttpGet]
        public IEnumerable<SuiteBO> Get()
        {
            return facade.SuiteService.GetAll();
        }

        // GET: api/Suites/5
        [HttpGet("{id}", Name = "Get")]
        public SuiteBO Get(int id)
        {
            return facade.SuiteService.Get(id);
        }
        
        // POST: api/Suites
        [HttpPost]
        public IActionResult Post([FromBody]SuiteBO suiteBO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.SuiteService.Create(suiteBO));
        }

        // PUT: api/Suites/5
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
        
        // DELETE: api/Suites/5
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
