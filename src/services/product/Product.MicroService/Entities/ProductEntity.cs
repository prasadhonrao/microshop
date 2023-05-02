using System.ComponentModel.DataAnnotations;

namespace Product.MicroService.Entities;

public class ProductEntity 
{
    [Key]
    [Required]
    public int ProductID { get; set; }
    public string? ProductName { get; set; }

}