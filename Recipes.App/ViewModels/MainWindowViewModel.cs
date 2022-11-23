﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Recipes.App.Commands;
using Recipes.App.Lib;
using Recipes.Models;
using Recipe = Recipes.App.Models.Recipe;

namespace Recipes.App.ViewModels;

public class MainWindowViewModel : BaseNotification
{
    private Recipe _recipe;
    public Recipe Recipe
    {
        get => _recipe;
        set => SetField(ref _recipe, value);
    }

    public ObservableCollection<Recipe> Recipes { get; set; }

    private string _search;
    public string Search
    {
        get => _search; 
        set => SetField(ref _search, value);
    }

    public LambdaCommand CommandSearch { get; set; }
    public LambdaCommand CommandClear { get; set; }

    public MainWindowViewModel()
    {
        Recipes = new ObservableCollection<Recipe>();
        Recipe = new Recipe();

        CommandSearch = new LambdaCommand(_ => true, async _ => await GetData());
        CommandClear = new LambdaCommand(_ => true, _ => Clear());
    }

    private async Task GetData()
    {
        var r = await EdaMamApi.GetRecipesAsync(Search);
        var t = await RecipesConverter.ConvertAsync(r);
        
        Recipes.Clear();
        foreach (var recipe in t)
        {
            Recipes.Add(recipe);
        }
        Clear();
    }

    private void Clear()
    {
        Search = string.Empty;
    }
}