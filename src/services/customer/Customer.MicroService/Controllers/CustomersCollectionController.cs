using AutoMapper;
using Customer.MicroService.Entities;
using Customer.MicroService.Models;
using Customer.MicroService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersCollectionController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomersCollectionController(
            ICustomerService customerService,
            IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpPost(Name = "CreateCustomersCollection")]
        public async Task<IActionResult> CreateCustomersCollection(
        [FromBody] IEnumerable<CustomerCreateModel> customerCollection)
        {
            var customerEntities = mapper.Map<IEnumerable<CustomerEntity>>(customerCollection);

            foreach (var customerEntity in customerEntities)
            {
                if (customerEntity != null)
                {
                    customerService.Add(customerEntity);
                }
            }

            await customerService.SaveChangesAsync();
            return Ok(customerEntities);
        }
    }
}
