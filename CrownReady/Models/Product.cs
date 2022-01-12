//  create a new class for product
namespace Models;
public class Product{
    // empty constructor
    public Product() {}

    // setting up automatic properties: name, description, price
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}