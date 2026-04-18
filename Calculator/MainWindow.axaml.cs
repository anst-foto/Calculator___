using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Calculator;

public partial class MainWindow : Window
{
    private readonly List<string> _historyResults = [];
    
    public MainWindow()
    {
        InitializeComponent();
        
        DataContext = this;
    }

    private void Button_Calc_OnClick(object? sender, RoutedEventArgs e)
    {
        if (!double.TryParse(Number1.Text ?? "", out var num1))
        {
            StatusBar.Text = $"Invalid number: {Number1?.Text}.";
            return;
        }
        
        if (!double.TryParse(Number2.Text ?? "", out var num2))
        {
            StatusBar.Text = $"Invalid number: {Number2?.Text}.";
            return;
        }

        var symbol = Symbol.Text;
        var result = symbol switch
        {
            "+" => $"{num1} + {num2} = {num1 + num2}",
            "/" => $"{num1} / {num2} = {num1 / num2}",
            _ => "Invalid operation."
        };
        
        _historyResults.Add(result);
        
        History.Text = "";
        History.Text = string.Join("\n",_historyResults);
    }
}