using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.Models;
using KFC.ViewModels;

namespace KFC.Views;

public partial class OrdersPageView : UserControl
{
    public OrdersPageView()
    {
        InitializeComponent();
    }

    public void InfoOrder(Order order)
    {
        (DataContext as OrdersPageViewModel).InfoOrderImpl(order);
    }
}