﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WarehouseMgmt.Application.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;

namespace WarehouseMgmt.Application.Services
{
    public class JWTService : IJWTService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;


        public JWTService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public string GenerateToken(string userName, string password)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string key = _configuration["Jwt:Key"];
            string issuer = _configuration["Jwt:Issuer"];
            string audiencia = _configuration["Jwt:Audience"];

            UserEntity user = _userRepository.GetByUserName(userName, password);

            var tokenKey = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim("UserId", user.Id.ToString()),
                }),
                Expires = System.DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
                Audience = audiencia
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenResponse = tokenHandler.WriteToken(token);

            return tokenResponse;

        }
    }
}