using System.Collections.Generic;

namespace InventorySystem.Models;

public class Warehouse
{
    public List<Item> Inventory { get; set; } = new();
    public List<Order> Orders { get; set; } = new();

    public Warehouse()
    {
        Inventory = new List<Item>
        {
            new Item { Name = "Screw",  PricePerUnit = 1.0m },
            new Item { Name = "Nut",    PricePerUnit = 1.5m },
            new Item { Name = "Pen",    PricePerUnit = 2.0m },
            new Item { Name = "Cable",  PricePerUnit = 4.0m }
        };

        Orders = new List<Order>
        {
            new Order
            {
                OrderLines = new List<OrderLine>
                {
                    new OrderLine { Item = Inventory[0], Quantity = 2 },
                    new OrderLine { Item = Inventory[1], Quantity = 3 },
                    new OrderLine { Item = Inventory[2], Quantity = 1 }
                }
            }
        };
    }
}