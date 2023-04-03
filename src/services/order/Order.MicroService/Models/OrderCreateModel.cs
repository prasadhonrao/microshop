using System.ComponentModel.DataAnnotations;

namespace Order.MicroService.Models;

public class OrderCreateModel 
{
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
}