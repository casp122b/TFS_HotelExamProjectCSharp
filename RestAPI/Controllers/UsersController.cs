using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        IBLLFacade facade;

        public UsersController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<UserBO> Get()
        {
            return facade.UserService.GetAll();
        }

        // GET: api/orders/5
        //[Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public UserBO Get(int id)
        {
            return facade.UserService.Get(id);
        }

        // POST: api/orders
        [HttpPost]
        public IActionResult Post([FromBody]UserBO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.UserService.Create(user));
        }

        //      api/ControllerName/id
        // PUT: api/orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserBO user)
        {
            if (id != user.Id)
            {
                return BadRequest("Path Id does not match Customer ID in json object");
            }
            try
            {
                var userUpdated = facade.UserService.Update(user);
                return Ok(userUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(facade.UserService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
