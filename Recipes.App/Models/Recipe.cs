using System.Collections.ObjectModel;

namespace Recipes.App.Models;

public class Recipe : BaseNotification
{
    private string _title;
    public string Title
    {
        get => _title; 
        set => SetField(ref _title, value);
    }
    
    public ObservableCollection<string> Ingredients { get; set; }
    public ObservableCollection<string> Instructions { get; set; }

    private string _image;
    public string Image
    {
        get => _image; 
        set => SetField(ref _image, value);
    }

    public Recipe()
    {
        Ingredients = new ObservableCollection<string>();
        Instructions = new ObservableCollection<string>();
    }
}