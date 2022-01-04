// namespace StoreFront;

// changing to 'namespace Models' to make things consistant
namespace Models;
public class StoreFront{
    public StoreFront() {}
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    // things to consider: whether or not it should be changed to private instead of public
    // private string _name;
    // public string GetName() {
    //     return this._name;
    // }
    // public void SetName(string name)
    // {
    //     this._name = name;
    // }
    // private string _address;
    // public string GetAddress() {
    //     return this._address;
    // }
    // public void SetAddress(string address)
    // {
    //     this._address = address;
    // }
    // private string _city;
    // public string GetCity() {
    //     return this._city;
    // }
    // public void SetCity(string city)
    // {
    //     this._city = city;
    // }
    // private string _state;
    // public string GetState() {
    //     return this._state;
    // }
    // public void SetState(string state)
    // {
    //     this._state = state;
    // }

    // Placeholder: this line should be for inventory
    public List<Inventory> Inventories { get; set; }

    // public override string ToString()
    // {
    //     return $"Name: {this.Name} \n Address: {this.Address} \nCity: {this.City} \nState: {this.State}";
    // }

    public string DisplayStoreFront()
    {
        return $"Name: {this.Name} Address: {this.Address}, {this.City}, {this.State}";
    }
}