using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using KFC.Context;
using KFC.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace KFC.ViewModels;

public class OrderInfoViewModel : ViewModelBase
{
    private ObservableCollection<OrderDish> _orderDishes;
    private ObservableCollection<Dish> _dishes;
    private ObservableCollection<User> _users;
    private ObservableCollection<UsersOrder> _usersOrders;
    private string _selectedValue;

    private static Order _selectOrder = new Order();
    
    private MyDbContext db = new MyDbContext();

    public Order SelectOrder
    {
        get => _selectOrder;
        set => this.RaiseAndSetIfChanged(ref _selectOrder, value);
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
    
    public string SelectedValue
    {
        get => _selectedValue;
        set => this.RaiseAndSetIfChanged(ref _selectedValue, value);
    }
    
    public ReactiveCommand<Window, Unit> Save { get; }
    public ReactiveCommand<Window, Unit> Delete { get; }
    public ReactiveCommand<Window, Unit> Cancel { get; }
    
    public List<string> ComboBoxValues { get; }
    
    public OrderInfoViewModel()
    {
        SelectOrder = OrdersPageViewModel.SelectOrder;
        var hgt = Helper.GetContext();
        OrderDishes = new ObservableCollection<OrderDish>(hgt.OrderDishes
            .Where(x => x.IdOrder == SelectOrder.IdOrder).ToList());
        Dishes = new ObservableCollection<Dish>(hgt.Dishes.ToList());
        Users = new ObservableCollection<User>(hgt.Users.ToList());
        UsersOrders = new ObservableCollection<UsersOrder>(hgt.UsersOrders.ToList());
        
        ComboBoxValues = new List<string> { "Нет", "Карта", "Наличные" };
        SelectedValue = ComboBoxValues.Where(x => x == SelectOrder.TypePayment).FirstOrDefault();

        Save = ReactiveCommand.Create<Window>(SaveImpl);
        Delete = ReactiveCommand.Create<Window>(DeleteImpl);
        Cancel = ReactiveCommand.Create<Window>(Cancelimpl);
    }

    private void Cancelimpl(Window obj)
    {
        obj.Close();
    }

    private void DeleteImpl(Window obj)
    {
        var order = db.Orders.Where(x => x.IdOrder == SelectOrder.IdOrder).FirstOrDefault();
        var userOrders = db.UsersOrders.Where(x => x.IdOrder == SelectOrder.IdOrder);
        var orderDish = db.OrderDishes.Where(x => x.IdOrder == SelectOrder.IdOrder);
        db.Orders.Remove(order);
        db.UsersOrders.RemoveRange(userOrders);
        db.OrderDishes.RemoveRange(orderDish);
        db.SaveChanges();
        MessageBoxManager.GetMessageBoxStandard("Успех", $"Заказ №{SelectOrder.IdOrder} удалён", ButtonEnum.Ok, Icon.Success).ShowAsync();
        obj.Close();
    }

    private void SaveImpl(Window obj)
    {
        if (SelectedValue != "Нет")
        {
            SelectOrder.TypePayment = SelectedValue;
            SelectOrder.Status = "Оплачено";
        }
        
        db.Orders.Update(SelectOrder);
        db.SaveChanges();
        MessageBoxManager.GetMessageBoxStandard("Успех", $"Заказ №{SelectOrder.IdOrder} сохранён", ButtonEnum.Ok, Icon.Success).ShowAsync();
        obj.Close();
    }
}