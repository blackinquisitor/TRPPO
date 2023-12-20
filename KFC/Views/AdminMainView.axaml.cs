using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.ViewModels;

namespace KFC.Views;

public partial class AdminMainView : Window
{
    public AdminMainView()
    {
        InitializeComponent();
        DataContext = new AdminMainViewModel();
    }
}