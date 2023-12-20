using System;
using System.Collections.ObjectModel;
using System.Linq;
using KFC.Models;
using KFC.Views;
using ReactiveUI;

namespace KFC.ViewModels;

public class OrdersPageViewModel : PageViewModelBase
{
    private ObservableCollection<Order> _orders;
    private ObservableCollection<OrderDish> _orderDishes;
    private ObservableCollection<Dish> _dishes;
    private ObservableCollection<User> _users;
    private ObservableCollection<UsersOrder> _usersOrders;

    public static Order SelectOrder;

    public ObservableCollection<Order> Orders
    {
        get => _orders;
        set => this.RaiseAndSetIfChanged(ref _orders, value);
    }

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

    public ObservableCollection<User> Users
    {
        get => _users;
        set => this.RaiseAndSetIfChanged(ref _users, value);
    }
    
    public ObservableCollection<UsersOrder> UsersOrders
    {
        get => _usersOrders;
        set => this.RaiseAndSetIfChanged(ref _usersOrders, value);
    }
    
    
    
    private bool _openOrderPage;
    
    public override bool OpenOrdersPage
    {
        get => _openOrderPage;
        protected set => this.RaiseAndSetIfChanged(ref _openOrderPage, value);
    }
    
    public override bool OpenProfilePage
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
    
    public override bool OpenNewOrderWaiterPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    
    public override bool OpenOrdersWaiterPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    

    public OrdersPageViewModel()
    {
        OpenOrdersPage = false;

        var hgt = Helper.GetContext();

        Orders = new ObservableCollection<Order>(hgt.Orders.ToList());
        OrderDishes = new ObservableCollection<OrderDish>(hgt.OrderDishes.ToList());
        Dishes = new ObservableCollection<Dish>(hgt.Dishes.ToList());
        Users = new ObservableCollection<User>(hgt.Users.ToList());
        UsersOrders = new ObservableCollection<UsersOrder>(hgt.UsersOrders.ToList());
    }

    public void InfoOrderImpl(Order order)
    {
        SelectOrder = order;
        OrderInfoView oiv = new OrderInfoView();
        oiv.Show();
    }
}