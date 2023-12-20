using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.ViewModels;

namespace KFC.Views;

public partial class CheckView : Window
{
    public CheckView()
    {
        InitializeComponent();
        DataContext = new CheckViewModel();
    }
}