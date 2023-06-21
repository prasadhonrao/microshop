using System.ComponentModel.DataAnnotations;

namespace Customer.MicroService.Models;

public class CustomerBaseModel 
{
    /* NOTE: 
     Do not set access modifiers of set to private as it breaks XML serialization. If you set it to private it does not return value in XML format.
     Also do not change it to record type as record does not support data annotations
    */

    [Required(ErrorMessage = "CompanyName is required")]
    [MaxLength(40)]
    public string CompanyName { get; set; }  = null!;

    [Required(ErrorMessage = "Contact Name is required")]
    [MaxLength(30)]
    public string ContactName { get; set; } = null!;

    [MaxLength(30)]
    public string ContactTitle { get; set; } = null!;

    [MaxLength(30)]
    public string Address { get; set; } = null!;

    [MaxLength(15)]
    public string City { get; set; } = null!;

    [MaxLength(15)]
    public string Region { get; set; } = null!;

    [MaxLength(10)]
    public string PostalCode { get; set; } = null!;

    [MaxLength(15)]
    public string Country { get; set; } = null!;

    [MaxLength(24)]
    public string Phone { get; set; } = null!;

    [MaxLength(24)]
    public string Fax { get; set; } = null!;

    public CustomerBaseModel(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
    {
        CompanyName = companyName;
        ContactName = contactName;
        ContactTitle = contactTitle;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
        Fax = fax;
    }

    protected CustomerBaseModel()
    {
    }

}