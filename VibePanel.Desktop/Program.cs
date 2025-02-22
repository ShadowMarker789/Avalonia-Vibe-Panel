using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System.Diagnostics;
using VibePanel;

namespace VibePanel.Desktop;


public static class Program
{
    static void Main(string[] args)
    {
        try
        {
            App.OnInit += App_OnInit;

            BuildAvaloniaApp()
            .UsePlatformDetect()
            .StartWithClassicDesktopLifetime(args);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Debug.WriteLine(e);
            Environment.Exit(-1);
        }
    }

    static void App_OnInit(object? sender, Avalonia.Controls.ApplicationLifetimes.IApplicationLifetime? e)
    {
        if (e is IClassicDesktopStyleApplicationLifetime lifetime)
        {
            Window w = new Window();
            lifetime.MainWindow = w;
            w.Content = new MainView();
            w.Show();
        }

    }

    // Avalonia configuration, don't remove; also used by visual designer.
    static AppBuilder BuildAvaloniaApp()
    {
        var builder = AppBuilder.Configure<App>()
                    .UseSkia()
                    .LogToTrace();

        //GC.KeepAlive(typeof(SvgImageExtension).Assembly);
        //GC.KeepAlive(typeof(Avalonia.Svg.Skia.Svg).Assembly);

        return builder;
    }
}