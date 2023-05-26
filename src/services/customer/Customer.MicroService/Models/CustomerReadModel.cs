namespace Customer.MicroService.Models;

public class CustomerReadModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName { get; set; } = null!;

    public CustomerReadModel()
    {
        
    }
    public CustomerReadModel(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        FullName = firstName + " " + lastName;
    }
}