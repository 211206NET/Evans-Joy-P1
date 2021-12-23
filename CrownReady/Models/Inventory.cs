namespace Models;
// create a new public class for inventory

public class Inventory{
    // empty constructor
    public Inventory() {}

    public int StoreId { get; set; }

    // setting up automatic properties: product, quantity
    public Product Item { get; set;}
    public int Quantity { get; set; }
    
}