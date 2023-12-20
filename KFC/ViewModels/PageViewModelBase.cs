namespace KFC.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public abstract bool OpenMenuDishesPage { get; protected set; }
    public abstract bool OpenEmployeesPage { get; protected set; }
    public abstract bool OpenProfilePage { get; protected set; }
    public abstract bool OpenOrdersPage { get; protected set; }
    public abstract bool OpenOrdersCookPage { get; protected set; }
    public abstract bool OpenNewOrderWaiterPage { get; protected set; }
    public abstract bool OpenOrdersWaiterPage { get; protected set; }
}