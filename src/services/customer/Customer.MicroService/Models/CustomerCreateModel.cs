namespace Customer.MicroService.Models;

public class CustomerCreateModel : CustomerBaseModel
{
    public CustomerCreateModel(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax) 
        : base(companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax)
    {
    }

    public CustomerCreateModel() : base()
    {
        
    }
}