using System;
using System.Collections.ObjectModel;

namespace Recipes.App.Models;

public class Recipe : BaseNotification
{
    public int Id { get; set; }
    
    private string _title;
    public string Title
    {
        get => _title; 
        set => SetField(ref _title, value);
    }

    private string _ingredients;
    public string Ingredients
    {
        get => _ingredients; 
        set => SetField(ref _ingredients, value);
    }

    private string _image;
    public string Image
    {
        get => _image; 
        set => SetField(ref _image, value);
    }

    public Recipe()
    { }
}