using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Api.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required, MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string PasswordHash { get; set; } = string.Empty;
    
    public double? Height { get; set; }
    public double? Weight { get; set; }
    public int? GoalCalories { get; set; }
    public string Gender { get; set; } = "Erkek";

    public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}