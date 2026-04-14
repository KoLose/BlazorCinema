using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.ApiRequest.Model;
using BlazorApp.Pages;

namespace BlazorApp.ApiRequest;

public class RequestApi
{
    private readonly HttpClient _httpClient;

    public RequestApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<MovieData> GetAllMoviesAsync()
    {
        var url = "/getAllMovies";

        try
        {
            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (string.IsNullOrEmpty(responseContent))
            {
                return new MovieData();
            }

            var userData = JsonSerializer.Deserialize<MovieData>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            
            return userData ?? new MovieData();
        }
        catch (Exception ex)
        {
            return new MovieData();
        }
    }

    public async Task<UserAddData> PostUserAsync(UserDataShort user)
    {
        var url = "/PostUserRole";
        try
        {
            var response = await _httpClient.PostAsJsonAsync(url, user).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var userData = JsonSerializer.Deserialize<UserAddData>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            
            return userData ?? new UserAddData();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return new UserAddData();
        }
    }
}