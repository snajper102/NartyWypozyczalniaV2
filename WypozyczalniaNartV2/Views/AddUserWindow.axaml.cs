using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WypozyczalniaNartV2.Views;

public partial class AddUserWindow : Window
{
    public AddUserWindow()
    {
        InitializeComponent();
        AvaloniaXamlLoader.Load(this);
    }
}