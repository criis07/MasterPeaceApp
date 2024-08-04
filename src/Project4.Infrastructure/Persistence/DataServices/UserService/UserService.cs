using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project4.Application.DTO.Users;
using Project4.Application.Interfaces.Persistence.DataServices.User;
using Project4.Domain.Entities;

namespace Project4.Infrastructure.Persistence.DataServices.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _config;

        public UserService(ApplicationDbContext applicationDbContext, IConfiguration config)
        {
            _applicationDbContext = applicationDbContext;
            _config = config;
        }
        public async Task<LoginResponse> LoginUserAsync(LoginDTO loginData)
        {
            var result = await findUserByEmail(loginData.Email!);

            if (result == null)
            {
                return new LoginResponse { Success = false, Message = "Invalid user" };
            }
            var checkPass = BCrypt.Net.BCrypt.Verify(loginData.Password, result.Password);

            var token = GenerateJWTToken(result).ToString();

            if (checkPass)
            {
                var response = new LoginResponse
                {
                    Success = true,
                    Message = "Access granted"
                };
                response.Token = token;

                return response;
            }
            return new LoginResponse { Success = false, Message = "Invalid credentials" };

        }

        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email!)
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> findUserByEmail(string email)
        {
           return await _applicationDbContext.users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO user)
        {
            var result = await findUserByEmail(user.Email!);

            if (result != null)
            {
                return new RegistrationResponse { Success = false, Message = "User already exist" };
            }

            _applicationDbContext.users.Add(new User
            {
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            });
            await _applicationDbContext.SaveChangesAsync();
            return new RegistrationResponse { Success = true, Message = "User registered" };
        }
    }
}
