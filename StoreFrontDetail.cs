namespace StoreFront;

public class StoreFrontDetail{
    // things to consider: whether or not it should be changed to private instead of public
    public StoreFrontDetail() {}
    public string address { get; set; }
    public string name { get; set; }

    // Placeholder: this line should be for inventory

    public string DisplayStoreFront()
    {
        return $"Name: {this.name} Address: {this.address}";
    }
}