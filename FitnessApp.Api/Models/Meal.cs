using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Api.Models;

public enum MealEntryType
{
    Library = 1,
    CustomFood = 2,
    QuickAdd = 3
}

public class Meal : BaseEntity
{
    [Required]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    
    [Required]
    public MealEntryType EntryType { get; set; }
    
    public int? FoodId { get; set; }
    [ForeignKey("FoodId")]
    public Food? Food { get; set; }
    
    [MaxLength(100)]
    public string? Name { get; set; }
    
    public double? GramAmount { get; set; }
    
    [Required]
    public int Calories { get; set; }
    
    [Required]
    public double Protein { get; set; }
    public double Carbs { get; set; } = 0;
    public double Fat { get; set; }
    public double Sugar { get; set; } = 0; 
    
    public bool IsFavorite { get; set; } = false;
    
    [Required]
    public DateTime Date { get; set; }
}