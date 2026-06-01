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

public class ApiService
{
    private readonly HttpClient _client;

    public ApiService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:5000/api/");
    }

    public async Task<List<UserDto>> GetUsersAsync()
    {
        ApiResponse<List<UserDto>> response = await _client.GetFromJsonAsync<ApiResponse<List<UserDto>>>("users") ?? throw new Exception("Null response from server");
        if (response.IsSuccess) return response.Data;
        else throw new Exception("an error has occured in the server !");
    }

    public async Task<UserDto> GetUserAsync(int userId)
    {
        ApiResponse<UserDto> response =  await _client.GetFromJsonAsync<ApiResponse<UserDto>>(
            $"users/{userId}") ?? throw new Exception("Null response from server");
        if (response.IsSuccess) return response.Data;
        else throw new Exception("an error has occured in the server !");
    }

    public async Task UpdateProfileAsync(int userId, WriteUserDto dto)
    {
        _client.PostAsJsonAsync(
            $"users/{userId}",
            dto);
    }
    
    public async Task UpdateProfileAsync(int userId, WriteUserDto dto)
    {
        _client.PostAsJsonAsync(
            $"users/{userId}",
            dto);
    }
}