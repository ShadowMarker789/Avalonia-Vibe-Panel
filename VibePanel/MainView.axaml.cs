using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace VibePanel;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        UpdateTextBlocks();
    }

    private async void LeftButton_Click(object? sender, RoutedEventArgs args)
    {
        try
        {
            DisableAllButtons();

            double velocity = 0.0;

            while (VibePanel.GetX(MainRectangle) > -1.0)
            {
                velocity += 0.001;
                VibePanel.SetX(MainRectangle, VibePanel.GetX(MainRectangle) - velocity);
                UpdateTextBlocks();
                await Task.Delay(7);
            }

            VibePanel.SetX(MainRectangle, -1.0);

            EnableAllButtons();
            UpdateTextBlocks();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            EnableAllButtons();
        }
    }

    private async void RightButton_Click(object? sender, RoutedEventArgs args)
    {
        try
        {
            DisableAllButtons();

            double velocity = 0.0;

            while (VibePanel.GetX(MainRectangle) < 1.0)
            {
                velocity += 0.001;
                VibePanel.SetX(MainRectangle, VibePanel.GetX(MainRectangle) + velocity);
                UpdateTextBlocks();
                await Task.Delay(7);
            }

            VibePanel.SetX(MainRectangle, 1.0);

            EnableAllButtons();
            UpdateTextBlocks();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            EnableAllButtons();
        }
    }

    private async void UpButton_Click(object? sender, RoutedEventArgs args)
    {
        try
        {
            DisableAllButtons();

            double velocity = 0.0;

            while (VibePanel.GetY(MainRectangle) > -1.0)
            {
                velocity += 0.001;
                VibePanel.SetY(MainRectangle, VibePanel.GetY(MainRectangle) - velocity);
                UpdateTextBlocks();
                await Task.Delay(7);
            }

            VibePanel.SetY(MainRectangle, -1.0);

            EnableAllButtons();
            UpdateTextBlocks();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            EnableAllButtons();
        }
    }

    private async void DownButton_Click(object? sender, RoutedEventArgs args)
    {
        try
        {
            DisableAllButtons();

            double velocity = 0.0;

            while (VibePanel.GetY(MainRectangle) < 1.0)
            {
                velocity += 0.001;
                VibePanel.SetY(MainRectangle, VibePanel.GetY(MainRectangle) + velocity);
                UpdateTextBlocks();
                await Task.Delay(7);
            }

            VibePanel.SetY(MainRectangle, 1.0);

            EnableAllButtons();
            UpdateTextBlocks();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            EnableAllButtons();
        }
    }

    private void UpdateTextBlocks()
    {
        // too lazy to bind 

        var x = VibePanel.GetX(MainRectangle);
        var y = VibePanel.GetY(MainRectangle);

        XTextBlock.Text = $"{x:f3}";
        YTextBlock.Text = $"{y:f3}";
    }

    private void DisableAllButtons()
    {
        LeftButton.IsEnabled = false;
        RightButton.IsEnabled = false;
        UpButton.IsEnabled = false;
        DownButton.IsEnabled = false;
    }

    private void EnableAllButtons()
    {
        LeftButton.IsEnabled = true;
        RightButton.IsEnabled = true;
        UpButton.IsEnabled = true;
        DownButton.IsEnabled = true;
    }

    //private async Task AnimateAsync()
    //{
    //    double x = 0, y = 0;

    //    System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

    //    while (!cts.IsCancellationRequested)
    //    {
    //        x = Math.Cos(sw.Elapsed.TotalSeconds);
    //        y = Math.Sin(sw.Elapsed.TotalSeconds * 1.1);

    //        VibePanel.SetX(MainEllipse, x);
    //        VibePanel.SetY(MainEllipse, y);

    //        XTextBlock.Text = $"{x:f3}";
    //        YTextBlock.Text = $"{y:f3}";

    //        await Task.Delay(4);
    //    }
    //}
}