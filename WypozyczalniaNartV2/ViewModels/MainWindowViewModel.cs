using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace WypozyczalniaNartV2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase _CurrentPage = new HomePageViewModel();

    [ObservableProperty] private ListItemTemplate? _selectedListItem; 
    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomePageViewModel)),
        new ListItemTemplate(typeof(AddRentPageViewModel)),
        new ListItemTemplate(typeof(AddUserPageViewModel)),
        new ListItemTemplate(typeof(AddSkisPageViewModel)),
        new ListItemTemplate(typeof(ShowAllPageViewModel)),
    };

    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;
        var instance = Activator.CreateInstance(value.ModelType);
        if (instance is null) return;
        CurrentPage = (ViewModelBase)instance;
    }
    
#pragma warning disable CA1822 // Mark members as static
    
public MainWindowViewModel()
{
    
}

#pragma warning restore CA1822 // Mark members as static
}

public class ListItemTemplate
{
    public ListItemTemplate(Type type)
    {
        ModelType = type;
        Label = type.Name.Replace("PageViewModel","");
    }
    public string Label { get; set; }
    public Type ModelType { get; set; }
}