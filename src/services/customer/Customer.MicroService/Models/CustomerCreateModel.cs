using System.ComponentModel.DataAnnotations;

namespace Customer.MicroService.Models;

public class CustomerCreateModel 
{
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(100)]
    public string FirstName { get; private set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(100)]
    public string LastName { get; private set; }

    public CustomerCreateModel(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}