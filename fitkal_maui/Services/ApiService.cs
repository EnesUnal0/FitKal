using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace fitkal.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    private readonly string _baseUrl = DeviceInfo.Platform == DevicePlatform.Android
        ? "https://10.0.2.2:57470"
        : "https://localhost:57470";

    public ApiService()
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

        _httpClient = new HttpClient(handler);
        _httpClient.BaseAddress = new Uri(_baseUrl);
        _httpClient.Timeout = TimeSpan.FromSeconds(10);
    }


    public async Task<bool> LoginAsync(string username, string password, bool beniHatirla)
    {
        try
        {
            var loginData = new
            {
                Username = username,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync("/api/auth/login", loginData);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();

                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    await SecureStorage.Default.SetAsync("jwt_token", result.Token);
                    Preferences.Default.Set("remember_me", beniHatirla);

                    return true;
                }
            }

            var hata = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Giriş başarısız: {response.StatusCode} - {hata}");

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Giriş hatası: {ex.Message}");
            return false;
        }
    }


    public async Task<bool> RegisterAsync(string username, string email, string password)
    {
        try
        {
            var registerData = new
            {
                Username = username,
                Email = email,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync("/api/auth/register", registerData);

            if (!response.IsSuccessStatusCode)
            {
                var hata = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Kayıt başarısız: {response.StatusCode} - {hata}");
            }

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sunucuya ulaşılamadı: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword)
    {
        try
        {
            var data = new
            {
                Username = username,
                OldPassword = oldPassword,
                NewPassword = newPassword
            };

            var json = System.Text.Json.JsonSerializer.Serialize(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("/api/auth/change-password", content);

            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<UserProfile?> GetProfileAsync()
    {
        await SetAuthTokenAsync();

        try
        {
            var response = await _httpClient.GetAsync("/api/profile");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserProfile>();
            }

            var hata = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Profil alınamadı: {response.StatusCode} - {hata}");

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Profil çekme hatası: {ex.Message}");
            return null;
        }
    }


    public async Task<bool> UpdateProfileAsync(UserProfile profileData)
    {
        await SetAuthTokenAsync();

        try
        {
            var response = await _httpClient.PutAsJsonAsync("/api/profile", profileData);

            if (!response.IsSuccessStatusCode)
            {
                var hata = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Profil güncelleme başarısız: {response.StatusCode} - {hata}");
            }

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Profil güncelleme hatası: {ex.Message}");
            return false;
        }
    }

   
    public async Task<List<FoodItem>> GetFoodsAsync(string searchQuery = "")
    {
        await SetAuthTokenAsync();

        try
        {
            string url = string.IsNullOrWhiteSpace(searchQuery)
                ? "/api/foods"
                : $"/api/foods?search={Uri.EscapeDataString(searchQuery)}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<FoodItem>>();
                return result ?? new List<FoodItem>();
            }

            var hata = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Besin listesi alınamadı: {response.StatusCode} - {hata}");

            return new List<FoodItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Besin listesi çekilirken hata oluştu: {ex.Message}");
            return new List<FoodItem>();
        }
    }


    public async Task<bool> AddMealAsync(int foodId, double grams)
    {
        await SetAuthTokenAsync();

        try
        {
            var mealData = new
            {
                FoodId = foodId,
                GramAmount = grams
            };

            var response = await _httpClient.PostAsJsonAsync("/api/meals", mealData);

            if (!response.IsSuccessStatusCode)
            {
                var hata = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Öğün ekleme başarısız: {response.StatusCode} - {hata}");
            }

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Öğün DB'ye kaydedilirken hata: {ex.Message}");
            return false;
        }
    }


    public async Task<bool> AddExerciseAsync(string exerciseName, double durationMinutes, double caloriesBurned)
    {
        await SetAuthTokenAsync();

        try
        {
            var exerciseData = new
            {
                Type = 0,
                DurationMinutes = durationMinutes,
                ManualCalories = caloriesBurned,
                Date = DateTime.Now
            };

            var response = await _httpClient.PostAsJsonAsync("/api/exercises", exerciseData);

            if (!response.IsSuccessStatusCode)
            {
                var hata = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Antrenman ekleme başarısız: {response.StatusCode} - {hata}");
            }

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Antrenman DB'ye kaydedilirken hata: {ex.Message}");
            return false;
        }
    }


    public async Task<DailySummaryDto?> GetDailySummaryAsync()
    {
        await SetAuthTokenAsync();

        try
        {
            var response = await _httpClient.GetAsync("/api/dashboard");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<DailySummaryDto>();
            }

            var hata = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Günlük özet alınamadı: {response.StatusCode} - {hata}");

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Günlük özet çekme hatası: {ex.Message}");
            return null;
        }
    }

 
    private async Task SetAuthTokenAsync()
    {
        var token = await SecureStorage.Default.GetAsync("jwt_token");

        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}


public class AuthResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;
}

public class UserProfile
{
    public string? Username { get; set; }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime? BirthDate { get; set; }

    public double? Height { get; set; }
    public double? Weight { get; set; }
    public double? TargetWeight { get; set; }

    public int? GoalCalories { get; set; }

    public string? Gender { get; set; }

    public int? ActivityLevel { get; set; }
}

public class FoodItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("caloriesPer100g")]
    public double Calories { get; set; }

    [JsonPropertyName("proteinPer100g")]
    public double Protein { get; set; }

    [JsonPropertyName("carbsPer100g")]
    public double Carbohydrate { get; set; }

    [JsonPropertyName("fatPer100g")]
    public double Fat { get; set; }

    [JsonPropertyName("sugarPer100g")]
    public double Sugar { get; set; }

    [JsonPropertyName("servingSize")]
    public string ServingSize { get; set; } = string.Empty;
}

public class DailySummaryDto
{
    [JsonPropertyName("dailyGoalCalories")]
    public double DailyGoalCalories { get; set; }

    [JsonPropertyName("totalEaten")]
    public double TotalCalories { get; set; }

    [JsonPropertyName("totalBurned")]
    public double TotalBurned { get; set; }

    [JsonPropertyName("netCalories")]
    public double NetCalories { get; set; }

    [JsonPropertyName("kalanKalori")]
    public double KalanKalori { get; set; }

    [JsonPropertyName("totalProtein")]
    public double TotalProtein { get; set; }

    [JsonPropertyName("totalCarbs")]
    public double TotalCarbohydrate { get; set; }

    [JsonPropertyName("totalFat")]
    public double TotalFat { get; set; }

    [JsonPropertyName("totalSugar")]
    public double TotalSugar { get; set; }

    [JsonPropertyName("caloriePercentage")]
    public double CaloriePercentage { get; set; }
}