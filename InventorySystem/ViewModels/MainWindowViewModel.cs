using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Threading;
using ReactiveUI;
using InventorySystem.Models;

namespace InventorySystem.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ItemSorterRobot _robot;

        private string _statusMessages;
        public string StatusMessages
        {
            get => _statusMessages;
            set => this.RaiseAndSetIfChanged(ref _statusMessages, value);
        }

        // Lager
        public ObservableCollection<Item> Items { get; } = new()
        {
            new Item { Name = "Apples", PricePerUnit = 3.5m },
            new Item { Name = "Bananas", PricePerUnit = 2.0m },
            new Item { Name = "Oranges", PricePerUnit = 4.0m }
        };

        // Ordrer
        public ObservableCollection<Item> OrderLines { get; } = new();

        // Indtjening
        private decimal _revenue;
        public decimal Revenue
        {
            get => _revenue;
            set => this.RaiseAndSetIfChanged(ref _revenue, value);
        }

        // Kommandoen til "Process Order"
        public ReactiveCommand<Unit, Unit> ProcessOrderCommand { get; }

        public MainWindowViewModel()
        {
            ProcessOrderCommand = ReactiveCommand.CreateFromTask(ProcessOrderAsync);
            StatusMessages = "Ready for new order...";

            _robot = new ItemSorterRobot();

            // Sikrer at UI ikke crasher, når baggrundstråde logger
            _robot.OnLog += msg =>
                Dispatcher.UIThread.Post(() => StatusMessages += msg + "\n");
            _robot.OnError += msg =>
                Dispatcher.UIThread.Post(() => StatusMessages += "❌ " + msg + "\n");
        }

        private async Task ProcessOrderAsync()
        {
            try
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    StatusMessages = "Processing order...";
                });

                // Tilføj eksempler på en ordre
                OrderLines.Clear();
                if (Items.Count >= 2)
                {
                    OrderLines.Add(Items[0]);
                    OrderLines.Add(Items[1]);
                }

                await Task.Delay(2000); // simulerer arbejde

                Revenue += 100m; // midlertidig testværdi

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    StatusMessages = "Order processed successfully ✅";
                });
            }
            catch (Exception ex)
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    StatusMessages += $"\n❌ ERROR: {ex.Message}";
                });
            }
        }
    }
}
