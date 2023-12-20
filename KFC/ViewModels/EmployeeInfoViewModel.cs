using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KFC.Models;
using ReactiveUI;

namespace KFC.ViewModels;

public class EmployeeInfoViewModel : ViewModelBase
{
    public static User SelectUserNow { get; set; }

    private ObservableCollection<Post> _posts;
    private ObservableCollection<StatusesUser> _statusesUsers;

    public ObservableCollection<Post> Posts
    {
        get => _posts;
        set => this.RaiseAndSetIfChanged(ref _posts, value);
    }

    public ObservableCollection<StatusesUser> StatusesUsers
    {
        get => _statusesUsers;
        set => this.RaiseAndSetIfChanged(ref _statusesUsers, value);
    }

    public EmployeeInfoViewModel()
    {
        SelectUserNow = EmployeesPageViewModel.SelectEmployee;
        Posts = new ObservableCollection<Post>(Helper.GetContext().Posts.ToList());
        StatusesUsers = new ObservableCollection<StatusesUser>(Helper.GetContext().StatusesUsers.ToList());
    }
}