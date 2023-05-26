using AutoMapper;
using Customer.MicroService.Controllers;
using Customer.MicroService.Entities;
using Customer.MicroService.Models;
using Customer.MicroService.Repositories;
using Customer.MicroService.Services;
using Customer.MicroService.Services.Sync;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Customer.MicroService.UnitTests.Controllers
{
    public class CustomerControllerTests
    {
        [Fact]
        public async Task GetAllCustomers_ReturnsAllCustomers()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<CustomerController>>();
            var mockOrderService = new Mock<IOrderDataService>();
            var mockCustomerService = new Mock<ICustomerService>();
            var mockMapper = new Mock<IMapper>();

            var expectedCustomers = new List<CustomerEntity>
            {
                new CustomerEntity(1, "John", "Doe")
            };

            var expectedCustomerReadModels = new List<CustomerReadModel>
            {
                new CustomerReadModel(2, "John", "Doe1")
            };

            mockCustomerService.Setup(service => service.GetAllAsync()).ReturnsAsync(expectedCustomers);
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<CustomerReadModel>>(expectedCustomers)).Returns(expectedCustomerReadModels);

            var controller = new CustomerController(mockCustomerService.Object, mockOrderService.Object, mockMapper.Object, mockLogger.Object);

            // Act
            var result = await controller.GetAllCustomers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCustomers = Assert.IsAssignableFrom<IEnumerable<CustomerReadModel>>(okResult.Value);
            Assert.Equal(expectedCustomerReadModels, returnedCustomers);
        }
    }
}