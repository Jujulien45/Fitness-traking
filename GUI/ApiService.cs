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
}

public class UserDto
{
    public in id {}
"age": 17,
"height_m": 195.0,
"id": 1,
"name": "Julien",
"sex": "M" or "F",
"weight_kg": 80.0
    public int Id { get; set; }
    public string Username { get; set; }
}

public class AddUserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
}

public class UpdateUserDto
{
    public string Bio { get; set; }
}

public class ApiService
{
    private readonly HttpClient _client;

    public ApiService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:5001/api/");
    }

    public async Task<List<UserDto>> GetUsersAsync()
    {
        return await _client.GetFromJsonAsync<List<UserDto>>("users");
    }

    public async Task<UserProfileDto> GetProfileAsync(int userId)
    {
        return await _client.GetFromJsonAsync<UserProfileDto>(
            $"users/{userId}/profile");
    }

    public async Task UpdateProfileAsync(int userId, UpdateProfileDto dto)
    {
        await _client.PutAsJsonAsync(
            $"users/{userId}/profile",
            dto);
    }
}