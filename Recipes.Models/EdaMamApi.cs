using System.Text.Json;

namespace Recipes.Models;

public static class EdaMamApi
{
    public static async Task<Root> GetRecipesAsync(string query)
    {
        const string APP_ID = "b4ea5e6d";
        const string APP_KEY = "185507ec3283f9d87cc2f0cb12739eac";
        var url = $"https://api.edamam.com/api/recipes/v2?app_id={APP_ID}&app_key={APP_KEY}&type=public&q={query}";

        using var client = new HttpClient();
        var stream = await client.GetStreamAsync(new Uri(url));
        return await JsonSerializer.DeserializeAsync<Root>(stream);
    }
}