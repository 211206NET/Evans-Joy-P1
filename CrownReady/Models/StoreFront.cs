// namespace StoreFront;
// changing to 'namespace Models' to make things consistant
namespace Models;
public class StoreFront{
    // things to consider: whether or not it should be changed to private instead of public
    public StoreFront() {}
    public string address { get; set; }
    public string name { get; set; }

    // Placeholder: this line should be for inventory
    public List<Inventory> Inventories { get; set; }

    public string DisplayStoreFront()
    {
        return $"Name: {this.name} Address: {this.address}";
    }
}