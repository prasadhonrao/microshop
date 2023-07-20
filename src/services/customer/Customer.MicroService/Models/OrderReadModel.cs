using System.Text.Json;
using System.Text.Json.Serialization;

namespace Customer.MicroService.Models;

public class OrderReadModel 
{
    [JsonPropertyName("orderNumber")]
    public string OrderNumber { get; set; }
    [JsonPropertyName("customerId")]
    public int CustomerID { get; set; }

    [JsonPropertyName("orderDate")]
    public DateTime OrderDate { get; set; }

    [JsonPropertyName("orderAmount")]
    public decimal OrderAmount { get; set; }

    [JsonPropertyName("orderLineItemModelList")]
    public List<OrderLineItemModel> OrderLineItemModelList { get; set; }

    public OrderReadModel()
    {
        // Default constructor for deserialization
    }

    public OrderReadModel(string orderId, int customerId, DateTime orderDate, decimal orderAmount, List<OrderLineItemModel> orderLineItemModelList = null)
    {
        OrderNumber = orderId;
        CustomerID = customerId;
        OrderDate = orderDate;
        OrderAmount = orderAmount;
        OrderLineItemModelList = orderLineItemModelList;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize<OrderReadModel>(this); 
    }

}