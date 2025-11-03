namespace InventorySystem.Models;

public class Item
{
    public string Name { get; set; } = string.Empty;
    public decimal PricePerUnit { get; set; }
    public uint InventoryLocation { get; set; } // 👈 Tilføj denne linje!

    public override string ToString() => $"{Name} ({PricePerUnit:C})";
}