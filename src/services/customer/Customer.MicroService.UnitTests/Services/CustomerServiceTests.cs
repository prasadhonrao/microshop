using Customer.MicroService.Entities;
using Customer.MicroService.Services;
using Customer.MicroService.UnitTests.Repositories;

namespace Customer.MicroService.UnitTests.Services
{
    public class CustomerServiceTests
    {
        [Fact]
        public async void Get_All_Customer()
        {
            // Arrange

            var customerTestRepository = new CustomerTestRepository();
            var customerService = new CustomerService(customerTestRepository);

            // Act

            var customers = await customerService.GetAllAsync();

            // Assert
            Assert.True(customers != null);
            Assert.True(customers.Count() == 3);
        }

        [Fact]
        public async void Get_Customer_With_Valid_Id()
        {
            // Arrange

            var customerTestRepository = new CustomerTestRepository();
            var customerService = new CustomerService(customerTestRepository);

            // Act

            var customer = await customerService.GetAsync(1);

            // Assert
            Assert.True(customer != null);
            Assert.True(customer.Id == 1);
            Assert.True(customer.FirstName == "John");
            Assert.True(customer.LastName == "Doe");
        }

        [Fact]
        public async Task Get_Customer_With_Negative_Id_Should_Throw_ArgumentException()
        {
            // Arrange

            var customerTestRepository = new CustomerTestRepository();
            var customerService = new CustomerService(customerTestRepository);
            int invalidId = -1;

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => customerService.GetAsync(invalidId));
        }

        [Fact]
        public async void Add_Customer_With_Valid_Data_Should_Add_The_Customer()
        {
            // Arrange

            var customerTestRepository = new CustomerTestRepository();
            var customerService = new CustomerService(customerTestRepository);

            // Act

            customerService.Add(new CustomerEntity(100, "Prasad", "Honrao"));
            var addedCustomer = await customerService.GetAsync(100);

            // Assert
            Assert.True(addedCustomer != null);
            Assert.Equal(100, addedCustomer.Id);
            Assert.Equal("Prasad", addedCustomer.FirstName);
            Assert.Equal("Honrao", addedCustomer.LastName);

        }

        [Fact]
        public void Add_Customer_Null_Value_Should_Throw_ArgumentNullException()
        {
            // Arrange

            var customerTestRepository = new CustomerTestRepository();
            var customerService = new CustomerService(customerTestRepository);

            // Act
            CustomerEntity entity = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => customerService.Add(entity));

        }

    }
}
