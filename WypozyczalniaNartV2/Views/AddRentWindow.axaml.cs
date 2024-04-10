using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WypozyczalniaNartV2.Views;

public partial class AddRentWindow : Window
{
    public AddRentWindow()
    {
        InitializeComponent();
        AvaloniaXamlLoader.Load(this);
    }
}