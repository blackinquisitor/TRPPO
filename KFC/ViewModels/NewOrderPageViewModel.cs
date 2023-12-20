using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using KFC.Models;
using KFC.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace KFC.ViewModels;

public class NewOrderPageViewModel : PageViewModelBase
{
    private bool _OpenNewOrderPage;

    private ObservableCollection<Dish> _dishes;

    private string _place;
    private float _price;
    private int _countClient;

    public static Order OrderToCheck;
    
    public ObservableCollection<Dish> Dishes
    {
        get => _dishes;
        set
        {
            this.RaiseAndSetIfChanged(ref _dishes, value);
            Price = Convert.ToSingle(Dishes.Where(x => x.SelectDish == true).Sum(x => x.Price * x.CountDishes));
        }
    }

    public string Place
    {
        get => _place;
        set  
        {
            this.RaiseAndSetIfChanged( ref _place, value);
            Price = Convert.ToSingle(Dishes.Where(x => x.SelectDish == true).Sum(x => x.Price * x.CountDishes));
        }
    }

    public float Price
    {
        get => _price;
        set => this.RaiseAndSetIfChanged(ref _price, value);
    }

    public int CountClient
    {
        get => _countClient;
        set => this.RaiseAndSetIfChanged(ref _countClient, value);
    }

    public override bool OpenNewOrderWaiterPage
    {
        get => _OpenNewOrderPage;
        protected set => this.RaiseAndSetIfChanged(ref _OpenNewOrderPage, value);
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
    
    public override bool OpenOrdersPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
    
    public override bool OpenOrdersWaiterPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    public ReactiveCommand<Window, Unit> AcceptOrder { get; }

    public NewOrderPageViewModel()
    {
        OpenNewOrderWaiterPage = false;

        Dishes = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());

        AcceptOrder = ReactiveCommand.Create<Window>(AcceptOrderImpl);
    }

    private void AcceptOrderImpl(Window obj)
    {
        Order newOrder = new Order();
        UsersOrder newUsersOrder = new UsersOrder();
        var selectDishes = Dishes.Where(x => x.SelectDish == true);

        newOrder.Place = Place;
        newOrder.Price = Price;
        newOrder.DateAndTime = DateTime.Now;
        newOrder.Status = "Принят";
        newOrder.TypePayment = "Нет";
        newOrder.CountClient = CountClient;
        newOrder.OrderDishes = selectDishes.Select(x => new OrderDish()
            { IdDishNavigation = x, Count = x.CountDishes }).ToList();
        
        OrderToCheck = newOrder;
        
        Helper.GetContext().Orders.Add(newOrder);
        Helper.GetContext().UpdateRange();
        Helper.GetContext().SaveChanges();
        
        var selectOrder = Helper.GetContext().Orders.OrderBy(f => f.DateAndTime).Last();
        newUsersOrder.IdOrder = selectOrder.IdOrder;
        newUsersOrder.IdUser = AuthorizationViewModel.AuthUser.IdUser; 

        Helper.GetContext().UsersOrders.Add(newUsersOrder);
        Helper.GetContext().UpdateRange();
        Helper.GetContext().SaveChanges();
       
        newOrder = null;
        CheckView cv = new CheckView();
        cv.Show();
    }
}