using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WypozyczalniaNartV2.ViewModels;

public partial class AddSkisPageViewModel : ViewModelBase
{
    public string? Company { get; set; }
    public string? Model { get; set; }
    public int Lenght { get; set; }
    public int Width { get; set; }
    public int  PricePerDay { get; set; }
    
    
    [ObservableProperty] private string? _textBlockName;

    [RelayCommand]
    private void ButtonOnClick()
    {
        if(Company!=null&& Model!=null)
            SqlUsage.AddSkisToDatabase(Company,Model,Lenght,Width,PricePerDay);
        TextBlockName = "Narty zostaly poprawnie zapisane";
    }
    
}