using System.ComponentModel.DataAnnotations;
using FitnessApp.Api.Models;

namespace FitnessApp.Api.DTOs;

public class UserRegisterDto
{
    [Required(ErrorMessage = "E-posta adresi zorunludur.")]
    [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi girin.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
    [MinLength(3, ErrorMessage = "Kullanıcı adı en az 3 karakter olmalıdır.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Şifre zorunludur.")]
    [MinLength(5, ErrorMessage = "Şifre en az 5 karakter olmalıdır.")]
    public required string Password { get; set; }
}

public class UserUpdateDto
{
    public string? Username { get; set; }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime? BirthDate { get; set; }

    public double? Height { get; set; }
    public double? Weight { get; set; }
    public double? TargetWeight { get; set; }

    public int? GoalCalories { get; set; }

    public string? Gender { get; set; }

    public ActivityLevel? ActivityLevel { get; set; }
}
public class UserLoginDto
{
    [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
    public required string Username { get; set; } 
    
    [Required(ErrorMessage = "Şifre zorunludur.")]
    public required string Password { get; set; }
}

public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public int UserId { get; set; }
}

public class ChangePasswordDto
{
    [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Eski şifre zorunludur.")]
    public required string OldPassword { get; set; }

    [Required(ErrorMessage = "Yeni şifre zorunludur.")]
    [MinLength(5, ErrorMessage = "Yeni şifre en az 5 karakter olmalıdır.")]
    public required string NewPassword { get; set; }
}