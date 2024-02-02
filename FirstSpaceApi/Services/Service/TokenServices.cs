using FirstSpaceApi.Services.IService;
using FirstSpaceApi.Shared.Database;
using FirstSpaceApi.Shared.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FirstSpaceApi.Shared.Domain.Enums;


namespace FirstSpaceApi.Services.Service
{
    public class TokenServices : ITokenServices
    {
        readonly DatabaseContext _databaseContext;
        public IConfiguration _configuration;
        public IGenericServices _genericServices;
        public TokenServices(DatabaseContext databaseContext, IConfiguration configuration, IGenericServices genericServices)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
            _genericServices = genericServices;
        }
        public TokenResponseVM GetAccessToken(TokenRequestVM login)
        {
            if (login != null && login.Email != null && login.Password != null)
            {
                // Get user info by email
                var user = _databaseContext.User.FirstOrDefault(x => x.Email == login.Email);
                if (user != null)
                {
                    // If user if valid create claim
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("Role", user?.Role.ToString()),
                        new Claim("UserName", user?.UserName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return new TokenResponseVM { Token = new JwtSecurityTokenHandler().WriteToken(token) };
                }
                else
                {   
                    throw new Exception("Invalid credentials");
                }
            }
            else
            {
                throw new Exception("BAD_REQUEST");
            }
        }
    }
}
