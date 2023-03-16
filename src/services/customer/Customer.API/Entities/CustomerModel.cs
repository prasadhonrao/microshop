using System.ComponentModel.DataAnnotations;

namespace Customer.API.Entities;

public class CustomerEntity 
{
    [Key]
    [Required]
    public int CustomerID { get; set; }
    public string? CompanyName { get; set; }
    [Required]
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }

}