using System;
using System.Collections.ObjectModel;
using System.Linq;
using KFC.Models;
using ReactiveUI;

namespace KFC.ViewModels;

public class OrdersWaiterPageViewModel : PageViewModelBase
{
    public static User AuthUserNow;
    private ObservableCollection<OrderDish> _orderDishes;
    private ObservableCollection<Dish> _dishes;
    private ObservableCollection<Order> _waiterOrders = new ObservableCollection<Order>();

    public ObservableCollection<OrderDish> OrderDishes
    {
        get => _orderDishes;
        set => this.RaiseAndSetIfChanged(ref _orderDishes, value);
    }

    public ObservableCollection<Dish> Dishes
    {
        get => _dishes;
        set => this.RaiseAndSetIfChanged(ref _dishes, value);
    }
    public ObservableCollection<Order> WaiterOrders
    {
        get => _waiterOrders;
        set => this.RaiseAndSetIfChanged(ref _waiterOrders, value);
    }
    
    private bool _OpenOrdersWaiterPage;
    public override bool OpenOrdersPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    
    public override bool OpenMenuDishesPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    public override bool OpenEmployeesPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    
    public override bool OpenOrdersCookPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    
    
    public override bool OpenProfilePage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    
    public override bool OpenNewOrderWaiterPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    
    public override bool OpenOrdersWaiterPage
    {
        get => _OpenOrdersWaiterPage;
        protected set => this.RaiseAndSetIfChanged(ref _OpenOrdersWaiterPage, value);
    }

    public OrdersWaiterPageViewModel()
    {
        AuthUserNow = AuthorizationViewModel.AuthUser;
        
        OpenOrdersWaiterPage = false;

        OrderDishes = new ObservableCollection<OrderDish>(Helper.GetContext().OrderDishes.ToList());
        Dishes = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
        
        var userOrders = Helper.GetContext().UsersOrders.Where(x => x.IdUser == AuthUserNow.IdUser).ToList();

        foreach (var uo in userOrders)
        {
            var waiterOrder = Helper.GetContext().Orders.
                Where(x => x.IdOrder == uo.IdOrder && x.DateAndTime.Day == DateTime.Now.Day).FirstOrDefault();
            
            if (waiterOrder != null)
            {
                WaiterOrders.Add(waiterOrder);
            }
        }
    }

    public void InfoOrderImpl(Order order)
    {
        OrdersPageViewModel opvm = new OrdersPageViewModel();
        opvm.InfoOrderImpl(order);
    }
}