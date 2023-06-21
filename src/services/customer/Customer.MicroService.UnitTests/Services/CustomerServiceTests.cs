using Customer.MicroService.Entities;
using Customer.MicroService.Services;
using Customer.MicroService.UnitTests.Repositories;

namespace Customer.MicroService.UnitTests.Services
{
    public class CustomerServiceTests
    {
        private readonly CustomerTestRepository customerTestRepository;
        private readonly OrderDataTestService orderDataService;
        private readonly CustomerService customerService;

        public CustomerServiceTests()
        {
            customerTestRepository = new CustomerTestRepository();
            orderDataService = new OrderDataTestService();
            customerService = new CustomerService(customerTestRepository, orderDataService);
        }

        [Fact]
        public async void Get_All_Customer()
        {
            // Arrange

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
            int invalidId = -1;

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => customerService.GetAsync(invalidId));
        }

        [Fact]
        public async void Add_Customer_With_Valid_Data_Should_Add_The_Customer()
        {
            // Arrange

            // Act

            customerService.Add(new CustomerEntity(100, "Prasad", "Honrao"));
            var addedCustomer = await customerService.GetAsync(100);

            // Assert
            Assert.True(addedCustomer != null);
            Assert.Equal(100, addedCustomer.CustomerID);
            Assert.Equal("Prasad", addedCustomer.FirstName);
            Assert.Equal("Honrao", addedCustomer.LastName);

        }

        [Fact]
        public void Add_Customer_Null_Value_Should_Throw_ArgumentNullException()
        {
            // Arrange

            // Act
            CustomerEntity entity = null!;

            // Assert
            Assert.Throws<ArgumentNullException>(() => customerService.Add(entity));

        }

    }
}
