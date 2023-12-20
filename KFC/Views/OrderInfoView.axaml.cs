using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.ViewModels;

namespace KFC.Views;

public partial class OrderInfoView : Window
{
    public OrderInfoView()
    {
        InitializeComponent();
        DataContext = new OrderInfoViewModel();
    }
}