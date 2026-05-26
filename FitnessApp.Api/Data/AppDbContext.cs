using FitnessApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    
    // Yeni eklediğimiz Besin Kütüphanesi tablosu
    public DbSet<Food> Foods { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}