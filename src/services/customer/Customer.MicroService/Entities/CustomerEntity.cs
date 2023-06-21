using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.MicroService.Entities;

[Table("Customers")]
public class CustomerEntity 
{
 
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Company Name is required")]
    [MaxLength(40)]
    public string CompanyName { get; set; } = null!;

    [Required(ErrorMessage = "Contact Name is required")]
    [MaxLength(30)]
    public string ContactName { get; set; } = null!;

    [MaxLength(30)]
    public string ContactTitle { get; set; } = null!;

    [MaxLength(30)]
    public string Address { get; set; } = null!;

    [MaxLength(15)]
    public string City { get; set; } = null!;

    [MaxLength(15)]
    public string Region { get; set; } = null!;

    [MaxLength(10)]
    public string PostalCode { get; set; } = null!;

    [MaxLength(15)]
    public string Country { get; set; } = null!;

    [MaxLength(24)]
    public string Phone { get; set; } = null!;

    [MaxLength(24)]
    public string Fax { get; set; } = null!;
}