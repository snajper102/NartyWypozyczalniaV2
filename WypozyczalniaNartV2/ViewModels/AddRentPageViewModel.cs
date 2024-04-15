using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WypozyczalniaNartV2.ViewModels;
public partial class AddRentPageViewModel : ViewModelBase
{
    public int Id_User { get; set; }
    public int Id_Skis { get; set; }
    public int Days { get; set; }
    public int Price { get; set; }
    public string? Date { get; set; }
    
    [ObservableProperty] private string? _textBlockName;
    
    [RelayCommand]
    private void ButtonOnClick()
    {

        if (Id_User != null && Id_Skis != null && Days != null && Price != null && Date != null)
        {
            SqlUsage.AddRentToDatabase(Id_User, Id_Skis, Days, Price, Date);
            TextBlockName = "Dane zostaly poprawnie zapisane"; 
        }
        else
        {
            TextBlockName = "Nie wpisales poprawnych danych";
        }
         
    }   
    
}