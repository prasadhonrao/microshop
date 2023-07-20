using System.Text.Json.Serialization;

namespace Customer.MicroService.Models
{
    public class OrderPublishModel
    {
        [JsonPropertyName("customerId")]
        public int CustomerID { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("orderAmount")]
        public decimal OrderAmount { get; set; }

        [JsonPropertyName("orderLineItemModelList")]
        public List<OrderLineItemModel> OrderLineItemModelList { get; set; }

        [JsonPropertyName("publishEvent")]
        public string PublishEvent { get; set; }

        public OrderPublishModel()
        {
            // Default constructor for deserialization
        }

        public OrderPublishModel(int customerId, DateTime orderDate, decimal orderAmount, List<OrderLineItemModel> orderLineItemModelList = null, string publishEvent = null)
        {
            CustomerID = customerId;
            OrderDate = orderDate;
            OrderAmount = orderAmount;
            OrderLineItemModelList = orderLineItemModelList;
            PublishEvent = publishEvent;
        }

    }
}
