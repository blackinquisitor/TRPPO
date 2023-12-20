using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using KFC.Models;
using KFC.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace KFC.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    private string _password;
    private string _login;
    public static User AuthUser { get; set; }

    private User _user;
    public User User
    {
        get => _user;
        set => this.RaiseAndSetIfChanged(ref _user, value);
    }
    public string Login
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    public ReactiveCommand<Window, Unit> ButtonEnter { get; }

    public AuthorizationViewModel()
    {
        ButtonEnter = ReactiveCommand.Create<Window>(OpenWindowImpl);
    }
    

    private void OpenWindowImpl(Window obj)
    {
        User user = null;
        user = Helper.GetContext().Users.SingleOrDefault(x => x.Login == Login & x.Password == Password);
        
        if (user != null)
        {
            if (user.IdStatus == 1)
            {
                SingIn(user, obj);
            }
            else
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы уволены", ButtonEnum.Ok).ShowAsync();
            }
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы ввели неверный логин или пароль", ButtonEnum.Ok).ShowAsync();
        }
    }

    private void SingIn(User user, Window obj)
    {
        AuthUser = user;
        if (user.IdPost == 1)
        {
            AdminMainView av = new AdminMainView();
            av.Show();
        }
        else if (user.IdPost == 2)
        {
            CookMainView cv = new CookMainView();
            cv.Show();
        }
        else if (user.IdPost == 3)
        {
            WaiterMainView cv = new WaiterMainView();
            cv.Show();
        }
        obj.Close();
    }
}