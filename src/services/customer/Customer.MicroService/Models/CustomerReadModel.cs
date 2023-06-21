namespace Customer.MicroService.Models;

public class CustomerReadModel : CustomerBaseModel
{
    public int Id { get; set; }
    public CustomerReadModel(int id, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax) 
        : base(companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax)
    {
        Id = id;
    }

    public CustomerReadModel() 
    {
    }
}