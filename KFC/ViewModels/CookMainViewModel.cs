using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using DynamicData;
using KFC.Context;
using KFC.Models;
using KFC.Views;
using ReactiveUI;

namespace KFC.ViewModels;

public class CookMainViewModel : ViewModelBase
{
    private MyDbContext db = new MyDbContext();
    
    private PageViewModelBase _CurrentPage;
    public PageViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }
    
    private readonly PageViewModelBase[] Pages = 
    { 
        new OrdersCookPageViewModel(),
        new ProfilePageViewModel()
    };
    
    public ICommand OpenOrdersCookPage { get; }
    public ICommand OpenProfilePage { get; }
    
    public ReactiveCommand<Window, Unit> ExitProfile { get; }
    
    public CookMainViewModel()
    {
        _CurrentPage = Pages[0];
        
        ExitProfile = ReactiveCommand.Create<Window>(ExitProfileImpl);

        var canOpenOrdersCookPageViewModel = this.WhenAnyValue(x => x.CurrentPage.OpenOrdersCookPage);
        OpenOrdersCookPage = ReactiveCommand.Create(OpenOrdersCookPageImpl, canOpenOrdersCookPageViewModel);
        var canOpenProfilePage = this.WhenAnyValue(x => x.CurrentPage.OpenProfilePage);
        OpenProfilePage = ReactiveCommand.Create(OpenProfilePageImpl, canOpenProfilePage);
    }

    private void ExitProfileImpl(Window obj)
    {
        AuthorizationView av = new AuthorizationView();
        AuthorizationViewModel.AuthUser = null;
        av.Show();
        obj.Close();
    }

    private void OpenOrdersCookPageImpl()
    {
        CurrentPage = Pages[0];
    }
    
    private void OpenProfilePageImpl()
    {
        CurrentPage = Pages[1];
    }
}