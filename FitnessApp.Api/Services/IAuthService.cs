using FitnessApp.Api.DTOs;
using Microsoft.AspNetCore.Http;

namespace FitnessApp.Api.Services
{
    public interface IAuthService
    {
        Task<IResult> RegisterAsync(UserRegisterDto dto);
        Task<IResult> LoginAsync(UserLoginDto dto);
        Task<IResult> ChangePasswordAsync(string username, ChangePasswordDto dto);
    }
}