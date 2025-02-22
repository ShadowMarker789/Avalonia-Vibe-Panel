using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;

namespace VibePanel;

public partial class MainView : UserControl
{
    private CancellationTokenSource cts = new();

    public MainView()
    {
        InitializeComponent();
    }

    protected override async void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        try
        {
            await AnimateAsync();
            base.OnAttachedToVisualTree(e);
        }
        catch (Exception)
        {
            // we messed up and I'm sorry
        }
    }

    private async Task AnimateAsync()
    {
        double x = 0, y = 0;

        System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

        while (!cts.IsCancellationRequested)
        {
            x = Math.Cos(sw.Elapsed.TotalSeconds);
            y = Math.Sin(sw.Elapsed.TotalSeconds * 1.1);

            VibePanel.SetX(MainEllipse, x);
            VibePanel.SetY(MainEllipse, y);

            XTextBlock.Text = $"{x:f3}";
            YTextBlock.Text = $"{y:f3}";

            await Task.Delay(4);
        }
    }
}