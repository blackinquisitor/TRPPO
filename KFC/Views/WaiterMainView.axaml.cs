using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.ViewModels;

namespace KFC.Views;

public partial class WaiterMainView : Window
{
    public WaiterMainView()
    {
        InitializeComponent();
        DataContext = new WaiterMainViewModel();
    }
}