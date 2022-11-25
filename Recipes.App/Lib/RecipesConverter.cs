using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Recipes.Models;
using Recipe = Recipes.App.Models.Recipe;

namespace Recipes.App.Lib;

public static class RecipesConverter
{
    public static async IAsyncEnumerable<Recipe> ConvertAsync(Root recipes)
    {
        foreach (var hit in recipes.Hits)
        {
            var recipe = hit.Recipe;
            yield return new Recipe
            {
                Title = recipe.Label,
                Ingredients = string.Join("\n", recipe.IngredientLines),
                Image = await DownloadImageAsync(recipe.Images.THUMBNAIL.Url, recipe.Label)
            };
        }
    }

    private static async Task<string> DownloadImageAsync(string url, string title)
    {
        var dir = $@"{Directory.GetCurrentDirectory()}\images";
        Directory.CreateDirectory(dir);
        var path = $@"{dir}\{title}.jpg";
        
        var http = new HttpClient();
        var response = await http.GetAsync(url);
        await using var file = new FileStream(path, FileMode.Create, FileAccess.Write);
        await response.Content.CopyToAsync(file);

        return path;
    }
}