namespace Microshop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Status { get; set; }
    public string? InventoryStatus { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;


}
