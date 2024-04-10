using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using WypozyczalniaNartV2.ViewModels;

namespace WypozyczalniaNartV2.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    
#if DEBUG
        this.AttachDevTools();
#endif

       this.WhenActivated(d => d(ViewModel.ShowAddUser.RegisterHandler(DoShowAddUserAsync)));
        this.WhenActivated(c => c(ViewModel.ShowRent.RegisterHandler(DoShowAddRentAsync)));
    }

    private async Task DoShowAddUserAsync(InteractionContext<MainWindowViewModel, AddUserWindowViewModel?> interaction)
    {
        var dialog = new AddUserWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<AddUserWindowViewModel?>(this);
        interaction.SetOutput(result);
    }
    private async Task DoShowAddRentAsync(InteractionContext<MainWindowViewModel, AddRentWindowViewModel?> interaction)
    {
        var dialog1 = new AddRentWindow();
        dialog1.DataContext = interaction.Input;

        var result1 = await dialog1.ShowDialog<AddRentWindowViewModel?>(this);
        interaction.SetOutput(result1);
    }

    
}