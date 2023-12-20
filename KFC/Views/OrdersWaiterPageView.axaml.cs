using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.Models;
using KFC.ViewModels;

namespace KFC.Views;

public partial class OrdersWaiterPageView : UserControl
{
    public OrdersWaiterPageView()
    {
        InitializeComponent();
        DataContext = new OrdersWaiterPageViewModel();
    }
    
    public void InfoOrder(Order order)
    {
        (DataContext as OrdersWaiterPageViewModel).InfoOrderImpl(order);
    }
}