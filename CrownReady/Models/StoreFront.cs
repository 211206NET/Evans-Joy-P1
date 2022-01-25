using CustomExceptions;
using System.Text.RegularExpressions;
using System.Data;
using System.ComponentModel.DataAnnotations; //check out

namespace Models;
public class StoreFront{
    // public StoreFront() {}
    public StoreFront()
    {
        this.Inventories = new List<Inventory>();
    }
    public StoreFront(string name)
    {
        this.Inventories = new List<Inventory>();
        this.Name = name;
    }
    public StoreFront(DataRow row)
    {
        this.ID = (int) row["ID"];
        this.Name = (string) row["Name"];
        this.Address = (string) row["Address"];
        this.City = (string) row["City"];
        this.State = (string) row["State"];
    }
    public int ID { get; set; }

    [Required]
    [RegularExpression("^[a-zA-Z0-9 !-?']+$", ErrorMessage = "Storefront name can only have alphanumeric characters, white space, !, -, ?, and '.")]
    public string Name { get; set; }
    // public string Name { 
    //     get => _name;
    //     set
    //     {
    //         Regex pattern = new Regex("^[a-zA-Z0-9 !-?']+$");
    //         if(string.IsNullOrWhiteSpace(value))
    //         {
    //             throw new InputInvalidException("Name can't be empty");
    //         }
    //         else if(!pattern.IsMatch(value))
    //         {
    //             throw new InputInvalidException("Storefront name can only have alphanumeric characters, white space, !, ?, and '.");
    //         }
    //         else
    //         {
    //             this._name = value;
    //         }
    //     }
    // }
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
        return $"ID: {this.ID} Name: {this.Name} Address: {this.Address}, {this.City}, {this.State}";
    }

    public override string ToString()
    {
        return $"Id: {this.ID} \nName: {this.Name} \nCity: {this.City} \nState: {this.State}";
    }
}