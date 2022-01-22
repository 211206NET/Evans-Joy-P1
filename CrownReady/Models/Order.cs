namespace Models;

public class Order
{
    public Order() {}
    public DateTime OrderDate { get; set; }
    //  public DateOnly OrderDate { get; set; }
    public int CustomerId { get; set; }
    public int OrderNumber { get; set; }
    public int StoreId { get; set; }
    public List<LineItem> LineItems { get; set; }
    public decimal Total { get; set; }

    public void CalculateTotal() {
        decimal total = 0;
    }
}