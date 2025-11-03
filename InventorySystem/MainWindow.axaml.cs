using Avalonia.Controls;
using InventorySystem.ViewModels;

namespace InventorySystem;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(); // ← dette binder XAML til ViewModel
    }
}