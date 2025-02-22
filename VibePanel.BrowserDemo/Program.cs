using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Avalonia.Controls.ApplicationLifetimes;
using VibePanel;

internal sealed partial class Program
{
    private static Task Main(string[] args)
    {
        App.OnInit += App_OnInit;

        return BuildAvaloniaApp()
            .WithInterFont()
            .StartBrowserAppAsync("out");
    }

    private static void App_OnInit(object? sender, Avalonia.Controls.ApplicationLifetimes.IApplicationLifetime? e)
    {
        if (e is ISingleViewApplicationLifetime lifetime)
        {
            lifetime.MainView = new MainView();
        }
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}