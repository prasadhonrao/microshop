namespace Customer.MicroService.Models
{
    public class CustomerSearchParametersModel : CustomerBaseModel
    {
        public CustomerSearchParametersModel(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax) 
            : base(companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax)
        {
        }

        public CustomerSearchParametersModel()
        {
            
        }
    }
}
