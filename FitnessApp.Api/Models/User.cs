using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Api.Models;
public enum ActivityLevel
{
    Sedentary = 0,
    LightlyActive = 1,
    ModeratelyActive = 2,
    VeryActive = 3
}
public class User : BaseEntity
{
    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Name { get; set; }

    [MaxLength(50)]
    public string? Surname { get; set; }

    public DateTime? BirthDate { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public double? TargetWeight { get; set; }

    public int? GoalCalories { get; set; }

    [MaxLength(20)]
    public string Gender { get; set; } = "Erkek";

    public ActivityLevel? ActivityLevel { get; set; }

    public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}