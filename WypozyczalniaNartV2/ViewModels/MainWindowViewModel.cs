using System;
using System.Dynamic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;
using CommunityToolkit.Mvvm.ComponentModel;


namespace WypozyczalniaNartV2.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _textBlockName = "pierwszy tekst ";

    public string TextBlockName
    {
        get => _textBlockName;
        set
        {
            _textBlockName = value;
            OnPropertyChanged();
        }
    }
    
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
    public string FirstName { get; set; }
    public string SecendName{ get; set; }
    
    public Interaction<MainWindowViewModel, AddUserWindowViewModel?> ShowAddUser { get; }
    public Interaction<MainWindowViewModel, AddRentWindowViewModel?> ShowRent { get; }
    
public ICommand AddUserButton { get; }
public ICommand AddRentButton { get; }


public MainWindowViewModel()
{
    
    
   // SqlUsage.DisplayDataFromSQLite();
    ShowAddUser = new Interaction<MainWindowViewModel, AddUserWindowViewModel?>();
    ShowRent = new Interaction<MainWindowViewModel, AddRentWindowViewModel?>();
    
    AddUserButton = ReactiveCommand.Create(async () =>
    {
        TextBlockName = "Clicked";
        //var store = new MainWindowViewModel();
        
        //var result = await ShowAddUser.Handle(store);
        
        Console.WriteLine(FirstName);
        Console.WriteLine(SecendName);
        
        
    });
    
    
    
    AddRentButton = ReactiveCommand.Create(async () =>
    {
        var store = new MainWindowViewModel();
        
        var result = await ShowRent.Handle(store);

       
    });
}

#pragma warning restore CA1822 // Mark members as static
}