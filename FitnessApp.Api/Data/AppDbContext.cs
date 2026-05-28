using System;
using System.Threading;
using System.Threading.Tasks;
using FitnessApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Food> Foods { get; set; } 

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.Now;
                entry.Entity.CreatedBy = "System"; // İleride buraya Login olan kullanıcının adı gelebilir
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedDate = DateTime.Now;
                entry.Entity.UpdatedBy = "System";
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Food>().HasData(
            new Food { Id = 1, Name = "Tavuk Göğsü", CaloriesPer100g = 165, ProteinPer100g = 31.0, CarbsPer100g = 0.0, FatPer100g = 3.6, SugarPer100g = 0.0 },
            new Food { Id = 2, Name = "Tavuk But", CaloriesPer100g = 120, ProteinPer100g = 19.0, CarbsPer100g = 0.0, FatPer100g = 4.0, SugarPer100g = 0.0 },
            new Food { Id = 3, Name = "Dana Kıyma", CaloriesPer100g = 250, ProteinPer100g = 17.0, CarbsPer100g = 0.0, FatPer100g = 20.0, SugarPer100g = 0.0 },
            new Food { Id = 4, Name = "Dana Kuşbaşı", CaloriesPer100g = 143, ProteinPer100g = 26.0, CarbsPer100g = 0.0, FatPer100g = 3.5, SugarPer100g = 0.0 },
            new Food { Id = 5, Name = "Hindi Göğsü", CaloriesPer100g = 114, ProteinPer100g = 23.7, CarbsPer100g = 0.0, FatPer100g = 1.5, SugarPer100g = 0.0 },
            new Food { Id = 6, Name = "Ton Balığı (Konserve)", CaloriesPer100g = 116, ProteinPer100g = 25.5, CarbsPer100g = 0.0, FatPer100g = 0.8, SugarPer100g = 0.0 },
            new Food { Id = 7, Name = "Somon Balığı", CaloriesPer100g = 208, ProteinPer100g = 20.4, CarbsPer100g = 0.0, FatPer100g = 13.4, SugarPer100g = 0.0 },
            new Food { Id = 8, Name = "Yumurta", CaloriesPer100g = 143, ProteinPer100g = 12.5, CarbsPer100g = 0.7, FatPer100g = 9.5, SugarPer100g = 0.3 },
            new Food { Id = 9, Name = "Tam Yağlı Süt", CaloriesPer100g = 61, ProteinPer100g = 3.2, CarbsPer100g = 4.8, FatPer100g = 3.3, SugarPer100g = 5.1 },
            new Food { Id = 10, Name = "Yarım Yağlı Süt", CaloriesPer100g = 47, ProteinPer100g = 3.3, CarbsPer100g = 4.8, FatPer100g = 1.5, SugarPer100g = 5.0 },
            new Food { Id = 11, Name = "Yoğurt", CaloriesPer100g = 61, ProteinPer100g = 3.5, CarbsPer100g = 4.7, FatPer100g = 3.3, SugarPer100g = 4.7 },
            new Food { Id = 12, Name = "Süzme Yoğurt", CaloriesPer100g = 97, ProteinPer100g = 9.0, CarbsPer100g = 4.0, FatPer100g = 5.0, SugarPer100g = 4.0 },
            new Food { Id = 13, Name = "Lor Peyniri", CaloriesPer100g = 98, ProteinPer100g = 11.1, CarbsPer100g = 3.4, FatPer100g = 4.3, SugarPer100g = 2.7 },
            new Food { Id = 14, Name = "Beyaz Peynir", CaloriesPer100g = 264, ProteinPer100g = 14.2, CarbsPer100g = 0.7, FatPer100g = 21.0, SugarPer100g = 0.5 },
            new Food { Id = 15, Name = "Kaşar Peyniri", CaloriesPer100g = 402, ProteinPer100g = 25.0, CarbsPer100g = 1.3, FatPer100g = 33.1, SugarPer100g = 0.5 },
            new Food { Id = 16, Name = "Yulaf Ezmesi", CaloriesPer100g = 389, ProteinPer100g = 16.9, CarbsPer100g = 66.3, FatPer100g = 6.9, SugarPer100g = 0.0 },
            new Food { Id = 17, Name = "Pirinç", CaloriesPer100g = 365, ProteinPer100g = 7.1, CarbsPer100g = 80.0, FatPer100g = 0.7, SugarPer100g = 0.1 },
            new Food { Id = 18, Name = "Bulgur", CaloriesPer100g = 342, ProteinPer100g = 12.3, CarbsPer100g = 75.9, FatPer100g = 1.3, SugarPer100g = 0.4 },
            new Food { Id = 19, Name = "Makarna", CaloriesPer100g = 371, ProteinPer100g = 13.0, CarbsPer100g = 74.7, FatPer100g = 1.5, SugarPer100g = 2.7 },
            new Food { Id = 20, Name = "Patates", CaloriesPer100g = 77, ProteinPer100g = 2.0, CarbsPer100g = 17.5, FatPer100g = 0.1, SugarPer100g = 0.8 },
            new Food { Id = 21, Name = "Tatlı Patates", CaloriesPer100g = 86, ProteinPer100g = 1.6, CarbsPer100g = 20.1, FatPer100g = 0.1, SugarPer100g = 4.2 },
            new Food { Id = 22, Name = "Tam Buğday Ekmeği", CaloriesPer100g = 247, ProteinPer100g = 13.0, CarbsPer100g = 41.3, FatPer100g = 3.4, SugarPer100g = 4.3 },
            new Food { Id = 23, Name = "Beyaz Ekmek", CaloriesPer100g = 266, ProteinPer100g = 8.9, CarbsPer100g = 49.3, FatPer100g = 3.3, SugarPer100g = 5.0 },
            new Food { Id = 24, Name = "Lavaş / Dürüm", CaloriesPer100g = 295, ProteinPer100g = 9.0, CarbsPer100g = 55.0, FatPer100g = 3.5, SugarPer100g = 2.0 },
            new Food { Id = 25, Name = "Kırmızı Mercimek", CaloriesPer100g = 358, ProteinPer100g = 23.9, CarbsPer100g = 63.1, FatPer100g = 2.2, SugarPer100g = 2.0 },
            new Food { Id = 26, Name = "Yeşil Mercimek", CaloriesPer100g = 353, ProteinPer100g = 25.8, CarbsPer100g = 60.1, FatPer100g = 1.1, SugarPer100g = 2.0 },
            new Food { Id = 27, Name = "Nohut", CaloriesPer100g = 364, ProteinPer100g = 19.3, CarbsPer100g = 61.0, FatPer100g = 6.0, SugarPer100g = 10.7 },
            new Food { Id = 28, Name = "Kuru Fasulye", CaloriesPer100g = 333, ProteinPer100g = 23.6, CarbsPer100g = 60.0, FatPer100g = 0.8, SugarPer100g = 2.1 },
            new Food { Id = 29, Name = "Barbunya", CaloriesPer100g = 333, ProteinPer100g = 23.6, CarbsPer100g = 60.0, FatPer100g = 0.8, SugarPer100g = 2.2 },
            new Food { Id = 30, Name = "Zeytinyağı", CaloriesPer100g = 884, ProteinPer100g = 0.0, CarbsPer100g = 0.0, FatPer100g = 100.0, SugarPer100g = 0.0 },
            new Food { Id = 31, Name = "Tereyağı", CaloriesPer100g = 717, ProteinPer100g = 0.9, CarbsPer100g = 0.1, FatPer100g = 81.1, SugarPer100g = 0.1 },
            new Food { Id = 32, Name = "Fıstık Ezmesi (Şekersiz)", CaloriesPer100g = 588, ProteinPer100g = 25.0, CarbsPer100g = 20.0, FatPer100g = 50.0, SugarPer100g = 9.2 },
            new Food { Id = 33, Name = "Badem", CaloriesPer100g = 579, ProteinPer100g = 21.2, CarbsPer100g = 21.6, FatPer100g = 49.9, SugarPer100g = 4.4 },
            new Food { Id = 34, Name = "Fındık", CaloriesPer100g = 628, ProteinPer100g = 15.0, CarbsPer100g = 16.7, FatPer100g = 60.8, SugarPer100g = 4.3 },
            new Food { Id = 35, Name = "Ceviz", CaloriesPer100g = 654, ProteinPer100g = 15.2, CarbsPer100g = 13.7, FatPer100g = 65.2, SugarPer100g = 2.6 },
            new Food { Id = 36, Name = "Kavrulmuş Yer Fıstığı", CaloriesPer100g = 585, ProteinPer100g = 23.7, CarbsPer100g = 21.3, FatPer100g = 49.7, SugarPer100g = 4.9 },
            new Food { Id = 37, Name = "Siyah Zeytin", CaloriesPer100g = 115, ProteinPer100g = 0.8, CarbsPer100g = 6.3, FatPer100g = 10.7, SugarPer100g = 0.0 },
            new Food { Id = 38, Name = "Yeşil Zeytin", CaloriesPer100g = 145, ProteinPer100g = 1.0, CarbsPer100g = 3.8, FatPer100g = 15.3, SugarPer100g = 0.5 },
            new Food { Id = 39, Name = "Bal", CaloriesPer100g = 304, ProteinPer100g = 0.3, CarbsPer100g = 82.4, FatPer100g = 0.0, SugarPer100g = 82.1 },
            new Food { Id = 40, Name = "Domates", CaloriesPer100g = 18, ProteinPer100g = 0.9, CarbsPer100g = 3.9, FatPer100g = 0.2, SugarPer100g = 2.6 },
            new Food { Id = 41, Name = "Salatalık", CaloriesPer100g = 15, ProteinPer100g = 0.7, CarbsPer100g = 3.6, FatPer100g = 0.1, SugarPer100g = 1.7 },
            new Food { Id = 42, Name = "Kuru Soğan", CaloriesPer100g = 40, ProteinPer100g = 1.1, CarbsPer100g = 9.3, FatPer100g = 0.1, SugarPer100g = 4.2 },
            new Food { Id = 43, Name = "Havuç", CaloriesPer100g = 41, ProteinPer100g = 0.9, CarbsPer100g = 9.6, FatPer100g = 0.2, SugarPer100g = 4.7 },
            new Food { Id = 44, Name = "Brokoli", CaloriesPer100g = 34, ProteinPer100g = 2.8, CarbsPer100g = 6.6, FatPer100g = 0.4, SugarPer100g = 1.7 },
            new Food { Id = 45, Name = "Ispanak", CaloriesPer100g = 23, ProteinPer100g = 2.9, CarbsPer100g = 3.6, FatPer100g = 0.4, SugarPer100g = 0.4 },
            new Food { Id = 46, Name = "Muz", CaloriesPer100g = 89, ProteinPer100g = 1.1, CarbsPer100g = 22.8, FatPer100g = 0.3, SugarPer100g = 12.2 },
            new Food { Id = 47, Name = "Elma", CaloriesPer100g = 52, ProteinPer100g = 0.3, CarbsPer100g = 13.8, FatPer100g = 0.2, SugarPer100g = 10.4 },
            new Food { Id = 48, Name = "Portakal", CaloriesPer100g = 47, ProteinPer100g = 0.9, CarbsPer100g = 11.8, FatPer100g = 0.1, SugarPer100g = 9.4 },
            new Food { Id = 49, Name = "Çilek", CaloriesPer100g = 32, ProteinPer100g = 0.7, CarbsPer100g = 7.7, FatPer100g = 0.3, SugarPer100g = 4.9 },
            new Food { Id = 50, Name = "Karpuz", CaloriesPer100g = 30, ProteinPer100g = 0.6, CarbsPer100g = 7.6, FatPer100g = 0.2, SugarPer100g = 6.2 },
            new Food { Id = 51, Name = "Pastırma (Çemensiz)", CaloriesPer100g = 250, ProteinPer100g = 30.0, CarbsPer100g = 0.0, FatPer100g = 14.0, SugarPer100g = 0.0 },
            new Food { Id = 52, Name = "Dana Ciğer", CaloriesPer100g = 135, ProteinPer100g = 20.0, CarbsPer100g = 4.0, FatPer100g = 4.0, SugarPer100g = 0.0 },
            new Food { Id = 53, Name = "Tavuk Kanat (Derili)", CaloriesPer100g = 200, ProteinPer100g = 18.0, CarbsPer100g = 0.0, FatPer100g = 15.0, SugarPer100g = 0.0 },
            new Food { Id = 54, Name = "Hamsi", CaloriesPer100g = 131, ProteinPer100g = 20.0, CarbsPer100g = 0.0, FatPer100g = 5.0, SugarPer100g = 0.0 },
            new Food { Id = 55, Name = "Levrek", CaloriesPer100g = 97, ProteinPer100g = 18.0, CarbsPer100g = 0.0, FatPer100g = 2.0, SugarPer100g = 0.0 },
            new Food { Id = 56, Name = "Kefir", CaloriesPer100g = 43, ProteinPer100g = 3.3, CarbsPer100g = 4.8, FatPer100g = 1.0, SugarPer100g = 4.8 },
            new Food { Id = 57, Name = "Çökelek", CaloriesPer100g = 85, ProteinPer100g = 14.0, CarbsPer100g = 2.0, FatPer100g = 1.0, SugarPer100g = 1.5 },
            new Food { Id = 58, Name = "Dil Peyniri", CaloriesPer100g = 250, ProteinPer100g = 20.0, CarbsPer100g = 1.0, FatPer100g = 18.0, SugarPer100g = 1.0 },
            new Food { Id = 59, Name = "Hellim Peyniri", CaloriesPer100g = 320, ProteinPer100g = 22.0, CarbsPer100g = 2.0, FatPer100g = 25.0, SugarPer100g = 1.0 },
            new Food { Id = 60, Name = "Tulum Peyniri", CaloriesPer100g = 350, ProteinPer100g = 25.0, CarbsPer100g = 2.0, FatPer100g = 27.0, SugarPer100g = 1.0 },
            new Food { Id = 61, Name = "Simit", CaloriesPer100g = 275, ProteinPer100g = 9.0, CarbsPer100g = 55.0, FatPer100g = 2.0, SugarPer100g = 5.0 },
            new Food { Id = 62, Name = "Kepek Ekmeği", CaloriesPer100g = 220, ProteinPer100g = 9.0, CarbsPer100g = 40.0, FatPer100g = 3.0, SugarPer100g = 3.0 },
            new Food { Id = 63, Name = "Çavdar Ekmeği", CaloriesPer100g = 259, ProteinPer100g = 9.0, CarbsPer100g = 48.0, FatPer100g = 3.0, SugarPer100g = 3.0 },
            new Food { Id = 64, Name = "Galeta (Sade)", CaloriesPer100g = 400, ProteinPer100g = 11.0, CarbsPer100g = 75.0, FatPer100g = 5.0, SugarPer100g = 2.0 },
            new Food { Id = 65, Name = "Yufka", CaloriesPer100g = 280, ProteinPer100g = 8.0, CarbsPer100g = 55.0, FatPer100g = 2.0, SugarPer100g = 1.0 },
            new Food { Id = 66, Name = "İrmik", CaloriesPer100g = 360, ProteinPer100g = 10.0, CarbsPer100g = 73.0, FatPer100g = 1.0, SugarPer100g = 1.0 },
            new Food { Id = 67, Name = "Tel Şehriye", CaloriesPer100g = 370, ProteinPer100g = 12.0, CarbsPer100g = 75.0, FatPer100g = 1.0, SugarPer100g = 1.0 },
            new Food { Id = 68, Name = "Mısır (Taze/Süt)", CaloriesPer100g = 96, ProteinPer100g = 3.0, CarbsPer100g = 21.0, FatPer100g = 1.5, SugarPer100g = 4.5 },
            new Food { Id = 69, Name = "Barbunya (Taze)", CaloriesPer100g = 130, ProteinPer100g = 9.0, CarbsPer100g = 23.0, FatPer100g = 0.5, SugarPer100g = 2.0 },
            new Food { Id = 70, Name = "Bamya (Çiğ)", CaloriesPer100g = 33, ProteinPer100g = 2.0, CarbsPer100g = 7.0, FatPer100g = 0.2, SugarPer100g = 1.5 },
            new Food { Id = 71, Name = "Yeşil Fasulye (Çiğ)", CaloriesPer100g = 31, ProteinPer100g = 1.8, CarbsPer100g = 7.0, FatPer100g = 0.2, SugarPer100g = 3.0 },
            new Food { Id = 72, Name = "Bezelye (Çiğ)", CaloriesPer100g = 81, ProteinPer100g = 5.4, CarbsPer100g = 14.5, FatPer100g = 0.4, SugarPer100g = 5.7 },
            new Food { Id = 73, Name = "Kabak Çekirdeği", CaloriesPer100g = 574, ProteinPer100g = 30.0, CarbsPer100g = 15.0, FatPer100g = 49.0, SugarPer100g = 1.3 },
            new Food { Id = 74, Name = "Antep Fıstığı", CaloriesPer100g = 560, ProteinPer100g = 20.0, CarbsPer100g = 28.0, FatPer100g = 45.0, SugarPer100g = 7.7 },
            new Food { Id = 75, Name = "Sarı Leblebi", CaloriesPer100g = 380, ProteinPer100g = 19.0, CarbsPer100g = 58.0, FatPer100g = 5.0, SugarPer100g = 10.0 },
            new Food { Id = 76, Name = "Tahin", CaloriesPer100g = 595, ProteinPer100g = 17.0, CarbsPer100g = 21.0, FatPer100g = 54.0, SugarPer100g = 0.5 },
            new Food { Id = 77, Name = "Kuru Kayısı", CaloriesPer100g = 240, ProteinPer100g = 3.0, CarbsPer100g = 63.0, FatPer100g = 0.5, SugarPer100g = 53.0 },
            new Food { Id = 78, Name = "Kuru İncir", CaloriesPer100g = 250, ProteinPer100g = 3.0, CarbsPer100g = 64.0, FatPer100g = 1.0, SugarPer100g = 48.0 },
            new Food { Id = 79, Name = "Kuru Üzüm", CaloriesPer100g = 300, ProteinPer100g = 3.0, CarbsPer100g = 79.0, FatPer100g = 0.5, SugarPer100g = 59.0 },
            new Food { Id = 80, Name = "Hurma (Medine)", CaloriesPer100g = 280, ProteinPer100g = 2.0, CarbsPer100g = 75.0, FatPer100g = 0.4, SugarPer100g = 63.0 },
            new Food { Id = 81, Name = "Kapya Biber", CaloriesPer100g = 26, ProteinPer100g = 1.0, CarbsPer100g = 6.0, FatPer100g = 0.3, SugarPer100g = 4.2 },
            new Food { Id = 82, Name = "Patlıcan", CaloriesPer100g = 25, ProteinPer100g = 1.0, CarbsPer100g = 6.0, FatPer100g = 0.2, SugarPer100g = 3.5 },
            new Food { Id = 83, Name = "Yeşil Kabak", CaloriesPer100g = 17, ProteinPer100g = 1.2, CarbsPer100g = 3.1, FatPer100g = 0.3, SugarPer100g = 2.5 },
            new Food { Id = 84, Name = "Beyaz Lahana", CaloriesPer100g = 25, ProteinPer100g = 1.3, CarbsPer100g = 5.8, FatPer100g = 0.1, SugarPer100g = 3.2 },
            new Food { Id = 85, Name = "Karnabahar", CaloriesPer100g = 25, ProteinPer100g = 1.9, CarbsPer100g = 5.0, FatPer100g = 0.3, SugarPer100g = 1.9 },
            new Food { Id = 86, Name = "Kültür Mantarı", CaloriesPer100g = 22, ProteinPer100g = 3.1, CarbsPer100g = 3.3, FatPer100g = 0.3, SugarPer100g = 2.0 },
            new Food { Id = 87, Name = "Pırasa", CaloriesPer100g = 61, ProteinPer100g = 1.5, CarbsPer100g = 14.2, FatPer100g = 0.3, SugarPer100g = 3.9 },
            new Food { Id = 88, Name = "Marul / Göbek", CaloriesPer100g = 15, ProteinPer100g = 1.4, CarbsPer100g = 2.9, FatPer100g = 0.2, SugarPer100g = 0.8 },
            new Food { Id = 89, Name = "Maydanoz", CaloriesPer100g = 36, ProteinPer100g = 3.0, CarbsPer100g = 6.3, FatPer100g = 0.8, SugarPer100g = 0.9 },
            new Food { Id = 90, Name = "Limon", CaloriesPer100g = 29, ProteinPer100g = 1.1, CarbsPer100g = 9.3, FatPer100g = 0.3, SugarPer100g = 2.5 }
        );
    }
}