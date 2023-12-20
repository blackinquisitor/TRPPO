using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.Models;
using KFC.ViewModels;

namespace KFC.Views;

public partial class EmployeesPageView : UserControl
{
    public EmployeesPageView()
    {
        InitializeComponent();
        DataContext = new EmployeesPageViewModel();
    }
    
    public void DismissEmployee(User user)
    {
        (DataContext as EmployeesPageViewModel).DismissEmployeeImpl(user);
    }

    public void InfoEmployee(User user)
    {
        (DataContext as EmployeesPageViewModel).InfoEmployeeImpl(user);
    }
}