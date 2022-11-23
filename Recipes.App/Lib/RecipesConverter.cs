using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Recipes.Models;

using Recipe = Recipes.App.Models.Recipe;

namespace Recipes.App.Lib;

public static class RecipesConverter
{
    public static async IAsyncEnumerable<Recipe> ConvertAsync(Root recipes)
    {
        foreach (var recipe in recipes.Hits.Select(hit => hit.Recipe))
        {
            yield return await Task.Run(() => new Recipe
            {
                Title = recipe.Label,
                Ingredients = new ObservableCollection<string>(recipe.IngredientLines),
                Image = recipe.Images.THUMBNAIL.Url
            });
        }
    }
}