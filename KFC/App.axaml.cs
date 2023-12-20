using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using KFC.ViewModels;
using KFC.Views;

namespace KFC;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new AuthorizationView()
            {
                DataContext = new AuthorizationViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}