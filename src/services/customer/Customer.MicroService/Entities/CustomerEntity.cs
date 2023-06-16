using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.MicroService.Entities;

[Table("Customers")]
public class CustomerEntity 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    public CustomerEntity()
    {
    }

    public CustomerEntity(int id, string firstName, string lastName) : this(firstName, lastName)
    {
        Id = id;
    }

    public CustomerEntity(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

}