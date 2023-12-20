using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.Context;
using KFC.ViewModels;

namespace KFC.Views;

public partial class AuthorizationView : Window
{
    public AuthorizationView()
    {
        InitializeComponent();
        DataContext = new AuthorizationViewModel();
        
    }
}