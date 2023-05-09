using System.ComponentModel.DataAnnotations;

namespace Customer.MicroService.Models;

public class OrderCreateModel 
{
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }

    public string Event { get; set; }
}