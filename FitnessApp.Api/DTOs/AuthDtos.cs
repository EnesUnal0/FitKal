namespace FitnessApp.Api.DTOs;

public class UserRegisterDto
{
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class UserUpdateDto
{
    public string? Username { get; set; }
    public double? Height { get; set; }
    public double? Weight { get; set; }
    public string? Gender { get; set; }
    public int? GoalCalories { get; set; }

}

public class UserLoginDto
{
    public required string Username { get; set; } 
    public required string Password { get; set; }
}

public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public int UserId { get; set; }
}