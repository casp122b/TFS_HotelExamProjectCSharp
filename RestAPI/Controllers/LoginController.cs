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
            var user = IsValidUserAndPasswordCombination(username);
            if (user == null)
            {
                return BadRequest();
            }
            else if (!VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest();
            }

            return Ok(new
            {
                username = user.Username,
                token = GenerateToken(user),
                role = user.Role
            });
        }

        UserBO IsValidUserAndPasswordCombination(string username)
        {
            //checks if username/password exists in the database. If they exist, the user is returned.
            List<UserBO> list = facade.UserService.GetAll();
            var userFound = list.FirstOrDefault(u => u.Username == username);
            return userFound;
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                        return false;
                }
            }

            return true;
        }

        string GenerateToken(UserBO user)
        {
            //a list of claims containing username, start time and expiration time is created.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            //If the role is Administrator, a role claim is added to the list of claims.
            if (user.Role == "Administrator")
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            //a token containing header (algorithm definition and key) and payload (the list of claims) is defined.
            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BOErgeOsTSpiser AErter 123 STK I ALT!")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                               null, // audience - not needed (ValidateAudience = false)
                               claims.ToArray(),
                               DateTime.Now,               // notBefore
                               DateTime.Now.AddDays(1)));  // expires

            //the token gets creates.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}