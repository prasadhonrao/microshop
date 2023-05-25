using System.ComponentModel.DataAnnotations;

namespace Order.MicroService.Entities;

public class OrderEntity 
{
    [Key]
    [Required]
    public int OrderID { get; set; }
    
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }

    public override string ToString() {
        return "OrderID: " + OrderID + ", CustomerID: " + CustomerID + ", OrderDate: " + OrderDate;
    }
}