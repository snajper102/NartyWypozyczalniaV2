
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace WypozyczalniaNartV2.ViewModels;

public partial class AddUserPageViewModel : ViewModelBase
{
    public static string? Name { get; set; }
    public static string? Surname { get; set; }
    public static string? Pesel { get; }
    public static string? City { get; set; }
    public static string? Street { get; set; }
    public static int ZipCode { get; set; }
   
    [ObservableProperty] private string? _textBlockName;
    
    [RelayCommand]
    private void ButtonOnClick()
    {

        if (Name != null && Surname != null && Pesel != null && City != null && Street != null)
        {
            SqlUsage.AddUserToDatabase(Name, Surname, Pesel, City, Street, ZipCode);
            TextBlockName = "Dane zostaly poprawnie zapisane";
        }
        else
            {
                TextBlockName = "Nie wpisales poprawnych danych";
            }
    }
    
}