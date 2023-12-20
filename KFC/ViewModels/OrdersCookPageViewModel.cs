using System;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData;
using KFC.Context;
using KFC.Models;
using ReactiveUI;

namespace KFC.ViewModels;

public class OrdersCookPageViewModel : PageViewModelBase
{
    private ObservableCollection<Dish> _dishes;
    private ObservableCollection<OrderDish> _orderDishes;
    private ObservableCollection<Order> _getOrder = new ObservableCollection<Order>();
    private ObservableCollection<Order> _setOrder = new ObservableCollection<Order>();
    
    private MyDbContext db = new MyDbContext();

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

    public ObservableCollection<Order> GetOrder
    {
        get => _getOrder;
        set => this.RaiseAndSetIfChanged(ref _getOrder, value);
    }

    public ObservableCollection<Order> SetOrder
    {
        get => _setOrder;
        set => this.RaiseAndSetIfChanged(ref _setOrder, value);
    }
    
    private bool _OpenOrdersCoockPage;
    
    public override bool OpenOrdersCookPage
    {
        get => _OpenOrdersCoockPage;
        protected set => this.RaiseAndSetIfChanged(ref _OpenOrdersCoockPage, value);
    }
    
    public override bool OpenEmployeesPage 
    { 
        get => true;
        protected set => throw new NotSupportedException(); 
    }
    
    public override bool OpenMenuDishesPage 
    { 
        get => true;
        protected set => throw new NotSupportedException(); 
    }
    
    public override bool OpenProfilePage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    
    public override bool OpenOrdersPage
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


    public OrdersCookPageViewModel()
    {
        OpenOrdersCookPage = false;
        
        Dishes = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
        OrderDishes = new ObservableCollection<OrderDish>(Helper.GetContext().OrderDishes.ToList());
        GetOrder.AddRange(Helper.GetContext().Orders.Where(x => x.Status == "Принят").ToList());
        SetOrder.AddRange(Helper.GetContext().Orders.
            Where(o => (o.Status == "Готовится") && o.DateAndTime.Day == DateTime.Now.Day));
    }
    
    public void GetOrderImpl(Order order)
    {
        order.Status = "Готовится";
        GetOrder.Remove(order);
        SetOrder.Add(order);
        db.Orders.Update(order);
        db.SaveChangesAsync();
    }
    
    public void SetOrderImpl(Order order)
    {
        order.Status = "Готово";
        db.Orders.Update(order);
        db.SaveChangesAsync();
        SetOrder.Remove(order);
        SetOrder.Add(order);
    }
}