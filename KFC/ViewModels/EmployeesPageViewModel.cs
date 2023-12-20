using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using DynamicData;
using KFC.Context;
using KFC.Models;
using KFC.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace KFC.ViewModels;

public class EmployeesPageViewModel : PageViewModelBase
{
    private User _newUser = new User();
    public static User SelectEmployee;
    private string _login;
    private string _password;
    private string _fName;
    private string _sName;
    private string _lName;
    private string _selectedImagePath;
    private string _selectedContractPath;

    private Post _selectPost;
    
    private ObservableCollection<User> _employees;
    private ObservableCollection<Post> _posts;
    private ObservableCollection<StatusesUser> _statusesUsers;
    
    public string ImagePath;
    public string ContractPath;
    public string DestImagePath;
    public string DestContractPath;
    public string ImageProgectPath;
    public string ContractProgectPath;
    public string AssetsUserPath = @"C:\8laba\KFC\KFC\AssetsUser";
    
    private MyDbContext db = new MyDbContext();
    
    private bool _OpenEmployeesPage;
    
    public ObservableCollection<User> Employees
    {
        get => _employees;
        set => this.RaiseAndSetIfChanged(ref _employees, value);
    }

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

    public Post SelectPost
    {
        get => _selectPost;
        set => this.RaiseAndSetIfChanged(ref _selectPost, value);
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
    
    public string FName
    {
        get => _fName;
        set => this.RaiseAndSetIfChanged(ref _fName, value);
    }
    
    public string SName
    {
        get => _sName;
        set => this.RaiseAndSetIfChanged(ref _sName, value);
    }
    
    public string LName
    {
        get => _lName;
        set => this.RaiseAndSetIfChanged(ref _lName, value);
    }
    
    public string SelectedImagePath
    {
        get => _selectedImagePath;
        set => this.RaiseAndSetIfChanged(ref _selectedImagePath, value);
    }
    
    public string SelectedContractPath
    {
        get => _selectedImagePath;
        set => this.RaiseAndSetIfChanged(ref _selectedImagePath, value);
    }
    
    public override bool OpenEmployeesPage 
    { 
        get => _OpenEmployeesPage;
        protected set => this.RaiseAndSetIfChanged(ref _OpenEmployeesPage, value);
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
    
    public ReactiveCommand<Unit, Unit> AddEmployee { get; }
    public ReactiveCommand<Window, Unit> SelectImageEmployee { get; }
    public ReactiveCommand<Window, Unit> SelectEmployeeContract { get; }
    

    public EmployeesPageViewModel()
    {
        OpenEmployeesPage = false;
        Employees = new ObservableCollection<User>(Helper.GetContext().Users.ToList());
        Posts = new ObservableCollection<Post>(Helper.GetContext().Posts.ToList());
        StatusesUsers = new ObservableCollection<StatusesUser>(Helper.GetContext().StatusesUsers.ToList());
        AddEmployee = ReactiveCommand.Create(AddEmployeeImpl);
        SelectImageEmployee = ReactiveCommand.Create<Window>(SelectImageEmployeeImpl);
        SelectEmployeeContract = ReactiveCommand.Create<Window>(SelectEmployeeContractImpl);
    }

    private async void SelectEmployeeContractImpl(Window obj)
    {
        var topLevel = TopLevel.GetTopLevel(obj);
        
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Выберите изображение",
            AllowMultiple = false,
        });

        ContractPath = Convert.ToString(files[0].Path.LocalPath);
        DestContractPath = $"{AssetsUserPath}/{files[0].Name}";
        SelectedContractPath = ContractPath;
        ContractProgectPath = $"AssetsUser/{files[0].Name}";
    }

    private async void SelectImageEmployeeImpl(Window obj)
    {
        var topLevel = TopLevel.GetTopLevel(obj);
        
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Выберите изображение",
            AllowMultiple = false,
        });

        ImagePath = Convert.ToString(files[0].Path.LocalPath);
        DestImagePath = $"{AssetsUserPath}/{files[0].Name}";
        SelectedImagePath = ImagePath;
        ImageProgectPath = $"AssetsUser/{files[0].Name}";
    }

    private void AddEmployeeImpl()
    {
        var user = Helper.GetContext().Users.FirstOrDefault(x=> x.Login == Login);
        var truePost = _posts.Where(p => p.SelectPost == true).FirstOrDefault();
        
        if (user == null)
        {
            _newUser.Login = _login;
            _newUser.Password = _password;
            _newUser.Fname = _fName;
            _newUser.Sname = _sName;
            _newUser.Lname = _lName;
            _newUser.IdPost = truePost.IdPost;
            _newUser.IdStatus = 1;
            _newUser.Photo = ImageProgectPath;
            _newUser.EmplContract = ContractProgectPath;
            File.Copy(ImagePath, DestImagePath, true);
            File.Copy(ContractPath, DestContractPath, true);
            Employees.Add(_newUser);
            _newUser.IdUser = 0;
            Helper.GetContext().Users.Add(_newUser);
            Helper.GetContext().SaveChanges();
            MessageBoxManager.GetMessageBoxStandard("Успех", "Сотрудник добавлен", ButtonEnum.Ok, Icon.Success).ShowAsync();
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Неверно указаны двнные", ButtonEnum.Ok, Icon.Error).ShowAsync();
        }
    }

    public void DismissEmployeeImpl(User u)
    {
        var user = db.Users.Where(p => p.IdUser == u.IdUser).FirstOrDefault();
        if (user.IdStatus == 1)
        {
            user.IdStatus = 2;
            Employees.Remove(u);
            Employees.Add(user);
            db.Users.Update(user);
            db.SaveChanges();
            MessageBoxManager.GetMessageBoxStandard("Успех", $"{u.Fname} {u.Lname} уволен", ButtonEnum.Ok, Icon.Success).ShowAsync();
        }
        else if (user.IdStatus == 2)
        {
            Employees.Remove(u);
            db.Users.Remove(user);
            db.SaveChanges();
            MessageBoxManager.GetMessageBoxStandard("Успех", $"{u.Fname} {u.Lname} удалён", ButtonEnum.Ok, Icon.Success).ShowAsync();
        }
    }

    public void InfoEmployeeImpl(User u)
    {
        SelectEmployee = u;
        EmployeeInfoView eiv = new EmployeeInfoView();
        eiv.Show();
    }
}