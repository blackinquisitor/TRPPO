using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using KFC.Views;
using KFC.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using Excel = Microsoft.Office.Interop.Excel;

namespace KFC.ViewModels;

public class WaiterMainViewModel : ViewModelBase
{
    
    private PageViewModelBase _CurrentPage;
    
    private ObservableCollection<Order> _orders;
    public PageViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }
    
    private readonly PageViewModelBase[] Pages = 
    { 
        new OrdersWaiterPageViewModel(),
        new NewOrderPageViewModel(),
        new ProfilePageViewModel(),
    };
    
    public ICommand OpenNewOrderPage { get; }
    public ICommand OpenOrdersPage { get; }
    public ICommand OpenProfilePage { get; }
    public ReactiveCommand<Window, Unit> CreateReport { get; }
    public ReactiveCommand<Window, Unit> ExitProfile { get; }
    public WaiterMainViewModel()
    {
        _CurrentPage = Pages[0];
        
        Orders = new ObservableCollection<Order>(Helper.GetContext().Orders.ToList());

        var canOpenNewOrderPage = this.WhenAnyValue((x => x.CurrentPage.OpenNewOrderWaiterPage));
        OpenNewOrderPage = ReactiveCommand.Create(OpenNewOrderPageImpl, canOpenNewOrderPage);
        
        var canOpenOrdersWaiterPage = this.WhenAnyValue((x => x.CurrentPage.OpenOrdersWaiterPage));
        OpenOrdersPage = ReactiveCommand.Create(OpenOrdersWaiterPageImpl, canOpenOrdersWaiterPage);
        
        var canOpenProfilePage = this.WhenAnyValue(x => x.CurrentPage.OpenProfilePage);
        OpenProfilePage = ReactiveCommand.Create(OpenProfilePageImpl, canOpenProfilePage);

        CreateReport = ReactiveCommand.Create<Window>(CreateReportImpl);
        ExitProfile = ReactiveCommand.Create<Window>(ExitProfileImpl);
    }

    public ObservableCollection<Order> Orders
    {
        get => _orders;
        set => this.RaiseAndSetIfChanged(ref _orders, value);
    }
    private void ExitProfileImpl(Window obj)
    {
        AuthorizationView av = new AuthorizationView();
        AuthorizationViewModel.AuthUser = null;
        av.Show();
        obj.Close();
    }
    
    private void OpenOrdersWaiterPageImpl()
    {
        CurrentPage = Pages[0];
    }

    private void OpenNewOrderPageImpl()
    {
        CurrentPage = Pages[1];
    }
    
    private void OpenProfilePageImpl()
    {
        CurrentPage = Pages[2];
    }
    
    private void CreateReportImpl(Window obj)
    {
         using(ExcelHelper helper = new ExcelHelper())
        {
            if (helper.Open(filePath: Path.Combine(Environment.CurrentDirectory, @"C:\Users\Public\Documents\Принятые заказы.xlsx")))
            {
                int i = 0;
                var allOrders = Orders.ToList().OrderBy(p => p.DateAndTime).ToList();
                var application = new Excel.Application();
                string[] month = new string[12] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", 
                                                            "Август", "Сентябрь", "Окрябрь", "Ноябрь", "Декабрь" };
                
                application.SheetsInNewWorkbook = month.Length;

                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                
                for (int j = 0; j < month.Length; ++j)
                {
                    int counter = 0;
                    int startRowIndex = 1;
                    
                    Excel.Worksheet worksheet = application.Worksheets.Item[j + 1];
                    worksheet.Name = month[j];

                    worksheet.Cells[1][startRowIndex] = "Номер";
                    worksheet.Cells[2][startRowIndex] = "Дата";
                    worksheet.Cells[3][startRowIndex] = "Цена";

                    startRowIndex++;

                    while (allOrders.Count > i)
                    {
                        if (allOrders[i].DateAndTime.Month == j + 1)
                        {
                            worksheet.Cells[1][startRowIndex] = allOrders[i].IdOrder;
                            worksheet.Cells[2][startRowIndex] = allOrders[i].DateAndTime.ToString("yy-MM-dd");
                            worksheet.Cells[3][startRowIndex] = allOrders[i].Price;
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                        i++;
                        startRowIndex++;
                    }
                    
                    Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex],
                        worksheet.Cells[2][startRowIndex]];
                    sumRange.Merge();
                    sumRange.Value = "Итого:";

                    worksheet.Cells[3][startRowIndex].Formula =
                        $"=SUM(C{startRowIndex - counter}:" + $"C{startRowIndex - 1}";

                    worksheet.Columns.AutoFit();
                    helper.Save();
                }
                application.Visible = true;
            }
        }
    }
}