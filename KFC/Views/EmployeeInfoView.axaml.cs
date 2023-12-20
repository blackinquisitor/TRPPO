using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.ViewModels;

namespace KFC.Views;

public partial class EmployeeInfoView : Window
{
    public EmployeeInfoView()
    {
        InitializeComponent();
        DataContext = new EmployeeInfoViewModel();
    }
}