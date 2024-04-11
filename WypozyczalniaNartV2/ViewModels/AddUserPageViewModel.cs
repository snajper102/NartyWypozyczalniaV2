using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;

namespace WypozyczalniaNartV2.ViewModels;

public partial class AddUserPageViewModel : ViewModelBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PESEL { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int ZipCode{ get; set; }
    
   [ObservableProperty] private string _textBlockName = "teraz jest zwykly ";
    
    //public ICommand SaveUserButton { get; }
[RelayCommand]
    private void ButtonOnClick()
    {
        SqlUsage.AddRecordToDatabase(Name,Surname,PESEL,City,Street,ZipCode);
        TextBlockName = "Dane zostaly poprawnie zapisane";
        
    }
    
    
    public AddUserPageViewModel()
    {
        //SaveUserButton = ReactiveCommand.Create(() =>

        //{
        //    SqlUsage.AddRecordToDatabase("jakub","Klimaczk","02133212","bieslko","zabia",43400);
        //    Console.WriteLine("Poprawnie dodano dane ");
         //  TextBlockName = "Dane zostaly zapisane prawidlowo";





       // });
    }
}