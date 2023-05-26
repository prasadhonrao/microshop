using System.ComponentModel.DataAnnotations;

namespace Customer.MicroService.Models;

public class OrderReadModel 
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }

    public OrderReadModel(int orderId, int customerId, DateTime orderDate)
    {
        OrderID = orderId;
        CustomerID = customerId;
        OrderDate = orderDate;
    }

    public override string ToString()
    {
        return "OrderID: " + OrderID + ", CustomerID: " + CustomerID + ", OrderDate: " + OrderDate;
    }

}