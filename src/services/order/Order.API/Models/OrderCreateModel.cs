using System.ComponentModel.DataAnnotations;

namespace Order.API.Models;

public class OrderCreateModel 
{
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
}