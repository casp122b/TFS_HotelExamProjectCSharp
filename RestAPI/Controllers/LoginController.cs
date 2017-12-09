using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController: Controller
    {
        IBLLFacade facade;

        public LoginController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        [HttpPost]
        public IActionResult Create([FromBody]LoginModel login)
        {
            var username = login.Username;
            var password = login.Password;
            var user = IsValidUserAndPasswordCombination(username, password);
            if (!string.IsNullOrEmpty(username) && user != null)
            {
                //var token = GenerateToken(user);
                return Ok(new
                {
                    username = user.Username,
                    token = GenerateToken(user)
                });
                //return new ObjectResult(token);
            }
            return BadRequest();
        }

        private UserBO IsValidUserAndPasswordCombination(string username, string password)
        {
            List<UserBO> list = facade.UserService.GetAll();
            var userFound = list.FirstOrDefault(u => u.Username == username && u.Password == password);
            return userFound;
        }

        private string GenerateToken(UserBO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            if (user.Role == "Administrator")
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));


            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BOErgeOsTSpiser AErter 123 STK I ALT!")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
