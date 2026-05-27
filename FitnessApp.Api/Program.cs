using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FitnessApp.Api.Data;
using FitnessApp.Api.DTOs;
using FitnessApp.Api.Models;
using FitnessApp.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Token girmek için kutuya 'Bearer ' yazıp boşluk bırakın ve token'ı yapıştırın.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(secretKey)
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/api/auth/register", async (UserRegisterDto dto, IAuthService authService) =>
{
    return await authService.RegisterAsync(dto);
});

app.MapPost("/api/auth/login", async (UserLoginDto dto, IAuthService authService) =>
{
    return await authService.LoginAsync(dto);
});

app.MapGet("/api/dashboard", async (AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var userData = await db.Users.FindAsync(userId);
    if (userData == null) return Results.NotFound();

    var today = DateTime.Today;
    var meals = await db.Meals.Where(m => m.UserId == userId && m.Date.Date == today).ToListAsync();
    var exercises = await db.Exercises.Where(e => e.UserId == userId && e.Date.Date == today).ToListAsync();

    double totalEaten = meals.Sum(m => m.Calories);
    double totalExerciseBurned = exercises.Sum(e => e.CaloriesBurned);

    double bmr = (10 * (userData.Weight ?? 0)) + (6.25 * (userData.Height ?? 0)) - (5 * 25);
    
    if (!string.IsNullOrEmpty(userData.Gender) && userData.Gender.Equals("Kadın", StringComparison.OrdinalIgnoreCase))
        bmr -= 161;
    else
        bmr += 5;

    double passiveBurn = bmr * 1.2;
    double grandTotalBurned = passiveBurn + totalExerciseBurned;
    double netCalories = totalEaten - grandTotalBurned;

    double goalCalories = Convert.ToDouble(userData.GoalCalories);
    double caloriePercentage = goalCalories > 0 ? Math.Round(totalEaten / goalCalories * 100, 1) : 0;

    return Results.Ok(new
    {
        DailyGoalCalories = userData.GoalCalories,
        TotalEaten = totalEaten,
        TotalBurned = Math.Round(grandTotalBurned),
        NetCalories = Math.Round(netCalories),
        KalanKalori = Math.Round(goalCalories - netCalories),
        TotalProtein = Math.Round(meals.Sum(m => m.Protein), 1),
        TotalCarbs = Math.Round(meals.Sum(m => m.Carbs), 1),
        TotalFat = Math.Round(meals.Sum(m => m.Fat), 1),
        TotalSugar = Math.Round(meals.Sum(m => m.Sugar), 1),
        CaloriePercentage = caloriePercentage
    });
}).RequireAuthorization();

app.MapGet("/api/meals/recent", async (AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var recentMeals = await db.Meals
        .Where(m => m.UserId == userId)
        .OrderByDescending(m => m.Date)
        .Take(5)
        .Select(m => new RecentMealsDto {
            Name = m.Name ?? "Bilinmeyen",
            Calories = m.Calories,
            Protein = m.Protein,
            Date = m.Date
        })
        .ToListAsync();

    return Results.Ok(recentMeals);
}).RequireAuthorization();

app.MapGet("/api/meals", async (AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var meals = await db.Meals
        .Where(m => m.UserId == userId)
        .Select(m => new MealResponseDto
        {
            Id = m.Id,
            EntryType = m.EntryType,
            FoodId = m.FoodId,
            Name = m.Name,
            GramAmount = m.GramAmount,
            Calories = m.Calories,
            Protein = m.Protein,
            Carbs = m.Carbs,
            Fat = m.Fat,
            Sugar = m.Sugar,
            Date = m.Date
        })
        .ToListAsync();

    return Results.Ok(meals);
}).RequireAuthorization();

app.MapPost("/api/meals", async (CreateMealDto dto, AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var meal = new Meal
    {
        UserId = userId,
        EntryType = dto.EntryType,
        FoodId = dto.FoodId,
        Name = dto.Name,
        GramAmount = dto.GramAmount,
        Date = dto.Date != default ? dto.Date : DateTime.Now
    };

    if (dto.EntryType == MealEntryType.Library && dto.FoodId.HasValue)
    {
        var food = await db.Foods.FindAsync(dto.FoodId.Value);
        if (food != null)
        {
            double multiplier = (dto.GramAmount ?? 100) / 100.0;
            meal.Name = food.Name;
            meal.Calories = (int)(food.CaloriesPer100g * multiplier);
            meal.Protein = food.ProteinPer100g * multiplier;
            meal.Carbs = food.CarbsPer100g * multiplier;
            meal.Fat = food.FatPer100g * multiplier;
            meal.Sugar = food.SugarPer100g * multiplier;
        }
    }
    else
    {
        meal.Calories = dto.Calories;
        meal.Protein = dto.Protein;
    }

    db.Meals.Add(meal);
    await db.SaveChangesAsync();

    return Results.Created($"/api/meals/{meal.Id}", new MealResponseDto
    {
        Id = meal.Id,
        EntryType = meal.EntryType,
        FoodId = meal.FoodId,
        Name = meal.Name,
        GramAmount = meal.GramAmount,
        Calories = meal.Calories,
        Protein = meal.Protein,
        Carbs = meal.Carbs,
        Fat = meal.Fat,
        Sugar = meal.Sugar, 
        Date = meal.Date
    });
}).RequireAuthorization();

app.MapPut("/api/meals/{id}", async (int id, UpdateMealDto dto, AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var meal = await db.Meals.FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
    if (meal == null) return Results.NotFound();

    if (meal.EntryType == MealEntryType.Library && meal.FoodId.HasValue)
    {
        var food = await db.Foods.FindAsync(meal.FoodId.Value);
        if (food != null)
        {
            double multiplier = (dto.GramAmount ?? 100) / 100.0;
            meal.GramAmount = dto.GramAmount;
            meal.Calories = (int)(food.CaloriesPer100g * multiplier);
            meal.Protein = food.ProteinPer100g * multiplier;
            meal.Carbs = food.CarbsPer100g * multiplier;
            meal.Fat = food.FatPer100g * multiplier;
            meal.Sugar = food.SugarPer100g * multiplier;
        }
    }
    else
    {
        meal.Name = dto.Name;
        meal.Calories = dto.Calories;
        meal.Protein = dto.Protein;
    }

    await db.SaveChangesAsync();
    return Results.Ok(new { message = "Guncellendi" });
}).RequireAuthorization();

app.MapDelete("/api/meals/{id}", async (int id, AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var meal = await db.Meals.FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
    if (meal == null) return Results.NotFound();

    db.Meals.Remove(meal);
    await db.SaveChangesAsync();

    return Results.NoContent();
}).RequireAuthorization();

app.MapGet("/api/exercises", async (AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var exercises = await db.Exercises
        .Where(e => e.UserId == userId)
        .Select(e => new ExerciseResponseDto
        {
            Id = e.Id,
            Name = e.Name,
            CaloriesBurned = e.CaloriesBurned,
            DurationMinutes = e.DurationMinutes,
            Date = e.Date
        })
        .ToListAsync();

    return Results.Ok(exercises);
}).RequireAuthorization();

app.MapPost("/api/exercises", async (CreateExerciseDto dto, AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    double finalBurned = 0;
    string exerciseName = "Manuel Egzersiz";

    if (dto.Type == ExerciseType.Manual)
    {
        finalBurned = dto.ManualCalories ?? 0;
    }
    else
    {
        double multiplier = dto.Type switch
        {
            ExerciseType.WalkingSlow => 3.0,
            ExerciseType.WalkingMedium => 5.0,
            ExerciseType.WalkingFast => 7.5,
            ExerciseType.Cycling => 8.0,
            ExerciseType.WeightTraining => 6.0,
            _ => 0
        };
        finalBurned = dto.DurationMinutes * multiplier;
        exerciseName = dto.Type.ToString();
    }

    var exercise = new Exercise
    {
        UserId = userId,
        Name = exerciseName,
        CaloriesBurned = finalBurned,
        DurationMinutes = dto.DurationMinutes,
        Date = dto.Date != default ? dto.Date : DateTime.Now
    };

    db.Exercises.Add(exercise);
    await db.SaveChangesAsync();

    return Results.Created($"/api/exercises/{exercise.Id}", new ExerciseResponseDto
    {
        Id = exercise.Id,
        Name = exercise.Name,
        CaloriesBurned = exercise.CaloriesBurned,
        DurationMinutes = exercise.DurationMinutes,
        Date = exercise.Date
    });
}).RequireAuthorization();

app.MapDelete("/api/exercises/{id}", async (int id, AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var exercise = await db.Exercises.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
    if (exercise == null) return Results.NotFound();

    db.Exercises.Remove(exercise);
    await db.SaveChangesAsync();

    return Results.NoContent();
}).RequireAuthorization();

app.MapGet("/api/profile", async (AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var userData = await db.Users.FindAsync(userId);
    if (userData == null) return Results.NotFound();

    return Results.Ok(new { 
        userData.Username, 
        userData.Height, 
        userData.Weight, 
        userData.GoalCalories,
        userData.Gender
    });
}).RequireAuthorization();

app.MapPut("/api/profile", async (UserUpdateDto dto, AppDbContext db, ClaimsPrincipal user) =>
{
    var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdString, out int userId)) return Results.Unauthorized();

    var userData = await db.Users.FindAsync(userId);
    if (userData == null) return Results.NotFound();

    userData.Username = dto.Username ?? userData.Username;
    userData.Height = dto.Height;
    userData.Weight = dto.Weight;
    userData.GoalCalories = dto.GoalCalories;
    userData.Gender = dto.Gender ?? userData.Gender;

    await db.SaveChangesAsync();
    return Results.Ok(new { message = "Guncellendi" });
}).RequireAuthorization();

app.MapPost("/api/foods", async (Food food, AppDbContext db) =>
{
    db.Foods.Add(food);
    await db.SaveChangesAsync();
    return Results.Ok(food);
});

app.MapGet("/api/foods", async (string? search, AppDbContext db) =>
{
    var query = db.Foods.AsQueryable();
    
    if (!string.IsNullOrWhiteSpace(search))
    {
        query = query.Where(f => f.Name.Contains(search));
    }

    var foods = await query.ToListAsync();
    return Results.Ok(foods);
});

app.MapDelete("/api/foods/{id}", async (int id, AppDbContext db) =>
{
    var food = await db.Foods.FindAsync(id);
    if (food == null) return Results.NotFound();

    db.Foods.Remove(food);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();