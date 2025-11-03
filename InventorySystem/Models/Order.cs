using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.Models;

public class Order
{
    public List<OrderLine> OrderLines { get; set; } = new();
    public DateTime Time { get; set; } = DateTime.Now;

    public decimal Total => OrderLines.Sum(x => x.TotalPrice);

    public override string ToString() =>
        $"Order ({OrderLines.Count} items, total {Total:C})";
}