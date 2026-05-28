using System;
using System.ComponentModel.DataAnnotations;
using FitnessApp.Api.Models; 

namespace FitnessApp.Api.DTOs;

public class CreateMealDto
{
    [Required]
    public MealEntryType EntryType { get; set; } 
    public int? FoodId { get; set; }
    public string? Name { get; set; }
    public double? GramAmount { get; set; }
    public int Calories { get; set; }
    public double Protein { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}

public class MealResponseDto
{
    public int Id { get; set; }
    public MealEntryType EntryType { get; set; }
    public int? FoodId { get; set; }
    public string? Name { get; set; }
    public double? GramAmount { get; set; }
    public int Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public double Sugar { get; set; }
    public DateTime Date { get; set; }
}

public class RecentMealsDto
{
    public string Name { get; set; } = string.Empty;
    public int Calories { get; set; }
    public double Protein { get; set; }
    public DateTime Date { get; set; }
}

public class UpdateMealDto
{
    public string? Name { get; set; }
    public double? GramAmount { get; set; }
    public int Calories { get; set; }
    public double Protein { get; set; }
}