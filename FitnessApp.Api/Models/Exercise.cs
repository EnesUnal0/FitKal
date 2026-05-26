using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Api.Models;

public class Exercise
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public double CaloriesBurned { get; set; }

    [Required]
    public double DurationMinutes { get; set; }

    [Required]
    public DateTime Date { get; set; }
}