using System;
using System.Reactive;
using Avalonia.Controls;
using KFC.Models;
using KFC.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace KFC.ViewModels;

public class ProfilePageViewModel : PageViewModelBase
{
    private bool _OpenProfilePage;
    
    public static User _AuthUserNow { get; set; }
    
    private string _firstpassword;
    private string _secondpassword;
    private string _oldpassword;
    
    public override bool OpenProfilePage
    {
        get => _OpenProfilePage;
        protected set => this.RaiseAndSetIfChanged(ref _OpenProfilePage, value);
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
    
    public string OldPassword
    {
        get => _oldpassword;
        set => this.RaiseAndSetIfChanged(ref _oldpassword, value);
    }
    public string FirstPassword
    {
        get => _firstpassword;
        set => this.RaiseAndSetIfChanged(ref _firstpassword, value);
    }
    public string SecondPassword
    {
        get => _secondpassword;
        set => this.RaiseAndSetIfChanged(ref _secondpassword, value);
    }
    
    public ReactiveCommand<Window, Unit> ChangePassword { get; }
    
    public ProfilePageViewModel()
    {
        _AuthUserNow = AuthorizationViewModel.AuthUser;;
        OpenProfilePage = false;
        ChangePassword = ReactiveCommand.Create<Window>(ChangePasswordImpl);
    }
    
    private void ChangePasswordImpl(Window obj)
    {
        if (_oldpassword == AuthorizationViewModel.AuthUser.Password)
        {
            if (_oldpassword != _firstpassword)
            {
                if (_firstpassword == _secondpassword)
                {
                    AuthorizationView av = new AuthorizationView();
                    AuthorizationViewModel.AuthUser.Password = _firstpassword;
                    Helper.GetContext().Users.Update(AuthorizationViewModel.AuthUser);
                    Helper.GetContext().SaveChanges();
                    MessageBoxManager.GetMessageBoxStandard("Успех", "Пароль изменён", ButtonEnum.Ok, Icon.Success).ShowWindowDialogAsync(obj);
                    av.Show();
                    obj.Close();
                }
                else
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка","Пароли не совпадают",  ButtonEnum.Ok, Icon.Error).ShowWindowDialogAsync(obj);
                    return;
                }
            }
            else
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка","Нельзя использовать старый пароль",  ButtonEnum.Ok, Icon.Error).ShowWindowDialogAsync(obj);
                return;
            }
            
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка","Неверный текущий пароль",  ButtonEnum.Ok, Icon.Error).ShowWindowDialogAsync(obj);
            return;
        }
    }
}