namespace FitnessApp.Api.Models;

public class Food : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double CaloriesPer100g { get; set; }
    public double ProteinPer100g { get; set; }
    public double CarbsPer100g { get; set; }
    public double FatPer100g { get; set; }
    public double SugarPer100g { get; set; }
}