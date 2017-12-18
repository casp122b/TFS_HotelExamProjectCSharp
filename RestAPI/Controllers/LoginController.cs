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
                return Ok(new
                {
                    username = user.Username,
                    token = GenerateToken(user),
                    role = user.Role
                });
            }

            return BadRequest();
        }

        UserBO IsValidUserAndPasswordCombination(string username, string password)
        {
            //checks if username/password exists in the database. If they exist, the user is returned.
            List<UserBO> list = facade.UserService.GetAll();
            var userFound = list.FirstOrDefault(u => u.Username == username && u.Password == password);
            return userFound;
        }

        string GenerateToken(UserBO user)
        {
            //a list of claims containing username, start time and expiration time is created.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            //If the role is Administrator, a role claim is added to the list of claims.
            if (user.Role == "Administrator")
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            //a token containing header (algorithm definition and key) and payload (the list of claims) is defined.
            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BOErgeOsTSpiser AErter 123 STK I ALT!")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            //the token gets creates.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}