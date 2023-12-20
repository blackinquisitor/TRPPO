using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.Models;
using KFC.ViewModels;

namespace KFC.Views;

public partial class OrdersCookPageView : UserControl
{
    public OrdersCookPageView()
    {
        InitializeComponent();
        DataContext = new OrdersCookPageViewModel();
    }
    
    public void GettingOrder(Order order)
    {
        (DataContext as OrdersCookPageViewModel).GetOrderImpl(order);
    }
    
    public void SettingOrder(Order order)
    {
        (DataContext as OrdersCookPageViewModel).SetOrderImpl(order);
    }
}