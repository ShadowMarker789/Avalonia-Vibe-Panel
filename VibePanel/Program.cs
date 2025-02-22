// See https://aka.ms/new-console-template for more information
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Themes.Fluent;
using System.Diagnostics;

namespace VibePanel;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            BuildAvaloniaApp()
            .SetupWithoutStarting();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Debug.WriteLine(e);
            Environment.Exit(-1);
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        var builder = AppBuilder.Configure<App>()
                    .UseSkia()
                    .LogToTrace();

        //GC.KeepAlive(typeof(SvgImageExtension).Assembly);
        //GC.KeepAlive(typeof(Avalonia.Svg.Skia.Svg).Assembly);

        return builder;
    }
}

public class App : Application
{
    public App()
    {
        Name = "HECK YEAH BEST APPLICATION EVA! ♥";

        Styles.Add(new FluentTheme());
        RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Dark;
    }

    public override void OnFrameworkInitializationCompleted()
    {
        OnInit?.Invoke(this, this.ApplicationLifetime);

        base.OnFrameworkInitializationCompleted();
    }

    public static event EventHandler<IApplicationLifetime?>? OnInit;

    public static bool IsBrowser { get; set; } = false;
}