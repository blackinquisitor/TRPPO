using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KFC.Models;
using KFC.ViewModels;

namespace KFC.Views;

public partial class MenuPageView : UserControl
{
    public MenuPageView()
    {
        InitializeComponent();
    }
    
    public void RemoveDish(Dish dish)
    {
        (DataContext as MenuPageViewModel).RemoveDishImpl(dish);
    }
}