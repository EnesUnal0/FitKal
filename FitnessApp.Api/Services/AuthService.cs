using FitnessApp.Api.Data;
using FitnessApp.Api.DTOs;
using FitnessApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessApp.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<IResult> RegisterAsync(UserRegisterDto dto)
        {
            if (dto.Username.Contains(" ") || dto.Password.Contains(" "))
                return Results.BadRequest("Kullanıcı adı veya şifre boşluk içeremez.");

            if (string.IsNullOrWhiteSpace(dto.Username) || dto.Username.Length < 3)
                return Results.BadRequest("Kullanıcı adı en az 3 karakter olmalıdır.");

            if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 5)
                return Results.BadRequest("Şifre en az 5 karakter olmalıdır.");

            if (!dto.Username.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')))
                return Results.BadRequest("Kullanıcı adı sadece İngilizce harf ve rakam içerebilir.");

            string turkishChars = "ğĞüÜşŞİıöÖçÇ";
            if (dto.Password.Any(c => turkishChars.Contains(c)))
                return Results.BadRequest("Şifre Türkçe karakter içeremez.");

            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return Results.BadRequest("Bu E-posta adresi zaten kullanılıyor.");

            if (await _db.Users.AnyAsync(u => u.Username == dto.Username))
                return Results.BadRequest("Bu kullanıcı adı zaten alınmış.");

            var user = new User
            {
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Results.Ok(new { message = "Hesap başarıyla oluşturuldu." });
        }

        public async Task<IResult> LoginAsync(UserLoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Results.Unauthorized();

            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]!);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username!)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Results.Ok(new AuthResponseDto
            {
                Token = tokenHandler.WriteToken(token),
                Username = user.Username,
                UserId = user.Id
            });
        }

        public async Task<IResult> ChangePasswordAsync(string username, ChangePasswordDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.OldPassword, user.PasswordHash))
                return Results.BadRequest("Eski şifre hatalı.");

            if (string.IsNullOrWhiteSpace(dto.NewPassword) || dto.NewPassword.Length < 5)
                return Results.BadRequest("Yeni şifre en az 5 karakter olmalıdır.");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _db.SaveChangesAsync();

            return Results.Ok(new { message = "Şifreniz başarıyla değiştirildi." });
        }
    }
}