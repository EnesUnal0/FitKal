using FitnessApp.Api.Models;

namespace FitnessApp.Api.DTOs;

public class CreateExerciseDto
{
    public ExerciseType Type { get; set; }
    public double DurationMinutes { get; set; }
    public double? ManualCalories { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}

public class ExerciseResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double CaloriesBurned { get; set; }
    public double DurationMinutes { get; set; }
    public DateTime Date { get; set; }
}