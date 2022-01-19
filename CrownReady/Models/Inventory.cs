namespace Models;
// create a new public class for inventory

public class Inventory{
    // empty constructor
    public Inventory() {}

    public int ID { get; set; }
    public int StoreId { get; set; }

    // setting up automatic properties: product, quantity
    public int ProductId { get; set;}
    // public Product Item { get; set;}
    public int Quantity { get; set; }
    public decimal Markup { get; set; }
    
    public string DisplayInventory()
    {
        return $"ID: {this.ID} StoreID: {this.StoreId} ProductID: {this.ProductId}, Quantity: {this.Quantity}, Markup: {this.Markup}";
    }
}