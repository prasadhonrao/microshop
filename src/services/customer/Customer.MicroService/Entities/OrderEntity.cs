using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.MicroService.Entities;

[Table("Orders")]
public class OrderEntity 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Order date is required")]
    [MaxLength(100)]
    public DateTime OrderDate { get; set; }

    public CustomerEntity Customer { get; set; }

    [Required(ErrorMessage = "Customer Id is required")]
    [ForeignKey("CustomerId")]    
    public int CustomerId { get; set; }

    public decimal OrderAmount { get; set; }

    public OrderEntity(int id, int customerId, DateTime orderDate, decimal orderAmount)
    {
        this.Id = id;
        this.CustomerId = customerId;
        this.OrderDate = orderDate;
        this.OrderAmount = orderAmount;
    }
 
}