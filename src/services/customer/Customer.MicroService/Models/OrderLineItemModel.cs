using System.Text.Json.Serialization;

namespace Customer.MicroService.Models
{
    public class OrderLineItemModel
    {
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("unitPrice")]
        public float UnitPrice { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("discount")]
        public float Discount { get; set; }

        public OrderLineItemModel()
        {
        }

        public OrderLineItemModel(string productId, float unitPrice, int quantity, float discount)
        {
            this.ProductId = productId;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.Discount = discount;
        }
    }

}