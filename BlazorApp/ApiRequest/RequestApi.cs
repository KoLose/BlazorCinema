using System.Text.Json;
using BlazorApp.ApiRequest.Model;

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
}