using Microsoft.IdentityModel.Tokens;
using NoteWebApi.Common;
using NoteWebApi.Dtos;
using NoteWebApi.Entities;
using NoteWebApi.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoteWebApi.Repository.Concretes
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<string>> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetUserNameAsync(dto.Username);

            if (user == null)
            {
                return ServiceResult<string>.Fail(new List<string> { "Kullanıcı bulunamadı" });
            }

            bool isPAsswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPAsswordValid)
            {
                return ServiceResult<string>.Fail(new List<string> { "Kullanıcının girdiği  paralo hatalı" });

            }

            var token = GenerateJwtToken(user);

            return ServiceResult<string>.Ok(token);


        }


        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.UserEmail)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
