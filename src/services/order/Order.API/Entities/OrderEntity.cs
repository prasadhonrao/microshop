using System.ComponentModel.DataAnnotations;

namespace Order.API.Entities;

public class OrderEntity 
{
    [Key]
    [Required]
    public int OrderID { get; set; }
    
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
}