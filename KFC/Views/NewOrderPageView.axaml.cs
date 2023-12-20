using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.ViewModels;

namespace KFC.Views;

public partial class NewOrderPageView : UserControl
{
    public NewOrderPageView()
    {
        InitializeComponent();
        DataContext = new NewOrderPageViewModel();
    }
}