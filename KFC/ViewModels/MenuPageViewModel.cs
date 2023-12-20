using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using KFC.Context;
using KFC.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace KFC.ViewModels;

public class MenuPageViewModel : PageViewModelBase
{
    private MyDbContext db = new MyDbContext();
    
    private bool _OpenMenuDishesPage;

    private ObservableCollection<Dish> _dishes;
    
    private string _Name;
    private float _Price;

    public ObservableCollection<Dish> Dishes
    {
        get => _dishes;
        set => this.RaiseAndSetIfChanged(ref _dishes, value);
    }
    
    public string Name
    {
        get => _Name;
        set => this.RaiseAndSetIfChanged(ref _Name, value);
    }
    
    public float Price
    {
        get => _Price;
        set => this.RaiseAndSetIfChanged(ref _Price, value);
    }
    
    public override bool OpenMenuDishesPage
    {
        get => _OpenMenuDishesPage;
        protected set => this.RaiseAndSetIfChanged(ref _OpenMenuDishesPage, value);
    }
    
    public override bool OpenEmployeesPage 
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
    
    public ReactiveCommand<Unit, Unit> AddDish { get; }
    
    public MenuPageViewModel()
    {
        OpenMenuDishesPage = false;
        AddDish = ReactiveCommand.Create(AddDishImpl);
        Dishes = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
    }

    public void RemoveDishImpl(Dish selectDish)
    {
        var dish = Dishes.Where(x => x.IdDish == selectDish.IdDish).FirstOrDefault();
        if (dish != null)
        {
            Dishes.Remove(selectDish);
            db.Dishes.Remove(dish);
            db.SaveChanges();
            MessageBoxManager.GetMessageBoxStandard("Успех", "Блюдо удалено", ButtonEnum.Ok, Icon.Success).ShowAsync();   
        }
    }
    
    private void AddDishImpl()
    {
        var dish = Helper.GetContext().Dishes.FirstOrDefault(x=> x.Name == Name);

        if (dish == null)
        {
            Dish newDish = new Dish();

            newDish.Name = Name;
            newDish.Price = Price;
            
            Dishes.Add(newDish);
            Helper.GetContext().Dishes.AddAsync(newDish);
            Helper.GetContext().SaveChanges();
            
            MessageBoxManager.GetMessageBoxStandard("Успех", "Блюдо добавлено", ButtonEnum.Ok, Icon.Success).ShowAsync();
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Блюдо с таким названием уже существует", ButtonEnum.Ok, Icon.Error).ShowAsync();
        }
    }
}