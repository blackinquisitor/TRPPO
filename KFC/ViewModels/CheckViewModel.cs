using System.Collections.ObjectModel;
using System.Linq;
using KFC.Models;
using ReactiveUI;

namespace KFC.ViewModels;

public class CheckViewModel : ViewModelBase
{
    private Order _order;
    private ObservableCollection<Dish> _dishes;
    private ObservableCollection<OrderDish> _orderDishes;

    public Order CheckOrder
    {
        get => _order;
        set => this.RaiseAndSetIfChanged(ref _order, value);
    }

    public ObservableCollection<Dish> Dishes
    {
        get => _dishes;
        set => this.RaiseAndSetIfChanged(ref _dishes, value);
    }

    public ObservableCollection<OrderDish> OrderDishes
    {
        get => _orderDishes;
        set => this.RaiseAndSetIfChanged(ref _orderDishes, value);
    }
    
    public CheckViewModel()
    {
        CheckOrder = NewOrderPageViewModel.OrderToCheck;
        Dishes = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
        OrderDishes = new ObservableCollection<OrderDish>(Helper.GetContext().OrderDishes
            .Where(x => x.IdOrder == CheckOrder.IdOrder).ToList());
    }
}