using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public ActionResult GetAccessToken()
        {
            //security key

            var security="Akbar First JWT Token"
            //Symmetric security key

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(security));


            //Signing Credentials

            var signin = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //Add Claims

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            claims.Add(new Claim("UserId", "10"));

            //Create Token

            var token = new JwtSecurityToken(
                issuer: "Akbar",
               audience: "Aathif",
               expires: DateTime.Now.AddHours(1),
               signingCredentials: signin,
               claims: claims
                );
            //return Token

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}