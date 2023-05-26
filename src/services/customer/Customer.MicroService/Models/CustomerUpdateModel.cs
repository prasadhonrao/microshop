using System.ComponentModel.DataAnnotations;

namespace Customer.MicroService.Models
{
    public class CustomerUpdateModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(100)]
        public string FirstName { get;  set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100)]
        public string LastName { get;  set; }

        public CustomerUpdateModel(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
