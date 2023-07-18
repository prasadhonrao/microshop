using System.Text.Json;

namespace Customer.MicroService.Models;

public class OrderReadModel 
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderAmount { get; set; }

    public OrderReadModel(int orderId, int customerId, DateTime orderDate, decimal orderAmount)
    {
        OrderID = orderId;
        CustomerID = customerId;
        OrderDate = orderDate;
        OrderAmount = orderAmount;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize<OrderReadModel>(this); 
    }

}