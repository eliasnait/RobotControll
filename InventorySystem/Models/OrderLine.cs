namespace InventorySystem.Models;

public class OrderLine
{
    public Item Item { get; set; } = new();
    public int Quantity { get; set; }

    public decimal TotalPrice => Item.PricePerUnit * Quantity;

    public override string ToString() =>
        $"{Quantity}x {Item.Name} = {TotalPrice:C}";
}