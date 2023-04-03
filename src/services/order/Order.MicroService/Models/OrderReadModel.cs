namespace Order.MicroService.Models;

public class OrderReadModel 
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
}