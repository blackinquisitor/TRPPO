using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.ViewModels;

namespace KFC.Views;

public partial class CookMainView : Window
{
    public CookMainView()
    {
        InitializeComponent();
        DataContext = new CookMainViewModel();
    }
}