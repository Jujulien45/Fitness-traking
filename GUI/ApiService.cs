using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Systeme_mutli_langages;

public class ApiResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    public bool IsSuccess =>
        string.Equals(Status, "ok",
            StringComparison.OrdinalIgnoreCase);
}

public struct Unit { }

public class UserDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("age")]
    public int Age { get; set; }
    [JsonPropertyName("height_m")]
    public float Height_m { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("sex")]
    public string Sex { get; set; }
    [JsonPropertyName("weight_kg")]
    public float Weight_kg { get; set; }
}

public class WriteUserDto
 {
     [JsonPropertyName("age")]
     public int Age { get; set; }
     [JsonPropertyName("height_m")]
     public float Height_m { get; set; }
     [JsonPropertyName("name")]
     public string Name { get; set; }
     [JsonPropertyName("sex")]
     public string Sex { get; set; }
     [JsonPropertyName("weight_kg")]
     public float Weight_kg { get; set; }
 }

public class BmiDto
{
    [JsonPropertyName("bmi")]
    public double Bmi { get; set; }
    [JsonPropertyName("date")]
    public string Date { get; set; }
    [JsonPropertyName("category")]
    public string Category { get; set; }
}

public class SessionDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
    [JsonPropertyName("duration_min")]
    public float DurationMin { get; set; }
    [JsonPropertyName("met")]
    public float Met { get; set; }
    [JsonPropertyName("calories")]
    public float Calories { get; set; }
    [JsonPropertyName("date")]
    public string Date { get; set; } = "";
}

public class WriteSessionDto
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
    [JsonPropertyName("duration_min")]
    public int DurationMin { get; set; }
    [JsonPropertyName("met")]
    public float Met { get; set; }
    [JsonPropertyName("date")]
    public string Date { get; set; } = "";
}

public class ActivityDto
{
    [JsonPropertyName("activity_id")]
    public int ActivityId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("met")]
    public float Met { get; set; }
}

public class StatsDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("total_kcal")]
    public double TotalKcal { get; set; }
    [JsonPropertyName("total_min")]
    public string TotalMin { get; set; } = "";
}


public class ApiService
{
    private readonly HttpClient _client;

    public ApiService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5000/api/");
    }

    public async Task<List<UserDto>> GetUsersAsync()
    {
        ApiResponse<List<UserDto>> response = await _client.GetFromJsonAsync<ApiResponse<List<UserDto>>>("users") ?? throw new Exception("Null response from server");
        if (!response.IsSuccess || response.Data is null) 
            throw new Exception("an error has occured in the server !");
        return response.Data;
    }

    public async Task<UserDto> GetUserAsync(int userId)
    {
        ApiResponse<UserDto> response =  await _client.GetFromJsonAsync<ApiResponse<UserDto>>(
            $"users/{userId}") ?? throw new Exception("Null response from server");
        if (!response.IsSuccess || response.Data is null) 
            throw new Exception("an error has occured in the server !");
        return response.Data;
    }

    public async Task UpdateUserAsync(int userId, WriteUserDto dto)
    {
        HttpResponseMessage httpResponse = await _client.PutAsJsonAsync($"users/{userId}", dto);
        if (!httpResponse.IsSuccessStatusCode)
        {
            var error = await httpResponse.Content.ReadAsStringAsync();
            throw new Exception($"Create failed: {error}");
        }
    }
    
    public async Task<UserDto> AddUserAsync(WriteUserDto dto)
    {
        HttpResponseMessage httpResponse = await _client.PostAsJsonAsync($"users", dto);
        if (!httpResponse.IsSuccessStatusCode)
        {
            var error = await httpResponse.Content.ReadAsStringAsync();
            throw new Exception($"Create failed: {error}");
        }
        
        ApiResponse<UserDto> response = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<UserDto>>()
                                        ?? throw new Exception("Null response from server");
        if (!response.IsSuccess || response.Data is null) 
            throw new Exception("an error has occured in the server !");

        return response.Data;
    }
    public async Task<List<BmiDto>> BmiHistoryAsync(int userId)
    {
        ApiResponse<List<BmiDto>> response =  await _client.GetFromJsonAsync<ApiResponse<List<BmiDto>>>(
            $"users/{userId}/bmi_history") ?? throw new Exception("Null response from server");
        if (!response.IsSuccess || response.Data is null) 
            throw new Exception("an error has occured in the server !");
        return response.Data;
    }
    public async Task<List<SessionDto>> GetSessionsAsync(int userId)
    {
        ApiResponse<List<SessionDto>> response = await _client.GetFromJsonAsync<ApiResponse<List<SessionDto>>>(
            $"sessions?user_id={userId}") ?? throw new Exception("Null response from server");
        if (!response.IsSuccess || response.Data is null)
            throw new Exception("An error has occurred in the server!");
        return response.Data;
    }

    public async Task AddSessionAsync(WriteSessionDto dto)
    {
        HttpResponseMessage httpResponse = await _client.PostAsJsonAsync("sessions", dto);
        if (!httpResponse.IsSuccessStatusCode)
        {
            var error = await httpResponse.Content.ReadAsStringAsync();
            throw new Exception($"Add session failed: {error}");
        }
    }

    public async Task<List<ActivityDto>> GetSessionTypesAsync()
    {
        ApiResponse<List<ActivityDto>> response = await _client.GetFromJsonAsync<ApiResponse<List<ActivityDto>>>(
            "sessions/types") ?? throw new Exception("Null response from server");
        if (!response.IsSuccess || response.Data is null)
            throw new Exception("An error has occurred in the server!");
        return response.Data;
    }

    public async Task<List<StatsDto>> GetUserStatsAsync(int userId)
    {
        ApiResponse<List<StatsDto>> response = await _client.GetFromJsonAsync<ApiResponse<List<StatsDto>>>(
            $"users/{userId}/stats") ?? throw new Exception("Null response from server");
        if (!response.IsSuccess || response.Data is null)
            throw new Exception("An error has occurred in the server!");
        return response.Data;
    }
}