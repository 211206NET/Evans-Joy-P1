namespace Models;

public class LineItem
{
    public int ID { get; set;}
    public int InventoryId { get; set; }
    public int OrderId { get; set; }
    public Product Item { get; set;}
    public int Quantity { get; set;}
}