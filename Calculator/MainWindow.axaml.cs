using Avalonia.Controls;
using Avalonia.Interactivity;
using Tmds.DBus.Protocol;

namespace Calculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Calc_OnClick(object? sender, RoutedEventArgs e)
    {
        if (!double.TryParse(Number1.Text ?? "", out var num1))
        {
            Result.Text = $"Invalid number: {Number1?.Text}.";
            return;
        }
        
        if (!double.TryParse(Number2.Text ?? "", out var num2))
        {
            Result.Text = $"Invalid number: {Number2?.Text}.";
            return;
        }

        var symbol = Symbol.Text;
        Result.Text = symbol switch
        {
            "+" => $"{num1} + {num2} = {num1 + num2}",
            "/" => $"{num1} / {num2} = {num1 / num2}",
            _ => "Invalid operation."
        };
    }
}