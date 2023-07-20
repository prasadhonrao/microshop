using AutoMapper;
using Customer.MicroService.Controllers;
using Customer.MicroService.Entities;
using Customer.MicroService.Models;
using Customer.MicroService.Services;
using Customer.MicroService.Services.Sync;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Customer.MicroService.UnitTests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomerService> customerServiceMock;
        private readonly Mock<IOrderService> orderServiceMock;

        private readonly Mock<IMapper> mapperMock;
        private readonly Mock<ILogger<CustomersController>> loggerMock;
        private readonly CustomersController controller;

        public CustomersControllerTests()
        {
            customerServiceMock = new Mock<ICustomerService>();
            orderServiceMock = new Mock<IOrderService>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<CustomersController>>();
            controller = new CustomersController(
                customerServiceMock.Object,
                orderServiceMock.Object,
                mapperMock.Object,
                loggerMock.Object
            );
        }


        //[Fact]
        //public async Task GetAllCustomers_ReturnsOkResultWithCustomers()
        //{
        //    // Arrange
        //    var customers = new List<CustomerEntity> { new CustomerEntity() };
        //    var customerReadModels = new List<CustomerReadModel> { new CustomerReadModel() };

        //    _customerServiceMock.Setup(service => service.GetAllAsync())
        //        .ReturnsAsync(customers);
        //    _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CustomerReadModel>>(customers))
        //        .Returns(customerReadModels);

        //    // Act
        //    var result = await _controller.GetAllCustomers();

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<IEnumerable<CustomerReadModel>>(okResult.Value);
        //    Assert.Equal(customerReadModels, model);
        //}

 
        //[Fact]
        //public async Task GetCustomerById_WithValidId_ReturnsOkResultWithCustomer()
        //{
        //    // Arrange
        //    var id = 1;
        //    var customer = new CustomerEntity { Id = id };
        //    var customerReadModel = new CustomerReadModel { Id = id };

        //    _customerServiceMock.Setup(service => service.GetAsync(id))
        //        .ReturnsAsync(customer);
        //    _mapperMock.Setup(mapper => mapper.Map<CustomerReadModel>(customer))
        //        .Returns(customerReadModel);

        //    // Act
        //    var result = await _controller.GetCustomerById(id);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<CustomerReadModel>(okResult.Value);
        //    Assert.Equal(customerReadModel, model);
        //}

        //[Fact]
        //public async Task CreateCustomer_WithValidModel_ReturnsCreatedAtRouteResult()
        //{
        //    // Arrange
        //    var model = new CustomerCreateModel ("John", "Doe" );
        //    var customerEntity = new CustomerEntity { Id = 1 };
        //    var customerReadModel = new CustomerReadModel { Id = 1 };

        //    _mapperMock.Setup(mapper => mapper.Map<CustomerEntity>(model))
        //        .Returns(customerEntity);
        //    _mapperMock.Setup(mapper => mapper.Map<CustomerReadModel>(customerEntity))
        //        .Returns(customerReadModel);

        //    // Act
        //    var result = await _controller.CreateCustomer(model);

        //    // Assert
        //    var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
        //    Assert.Equal(nameof(CustomerController.GetCustomerById), createdAtRouteResult.RouteName);
        //    Assert.Equal(customerReadModel, createdAtRouteResult.Value);
        //}

        //[Fact]
        //public async Task UpdateCustomer_WithValidIdAndModel_ReturnsNoContentResult()
        //{
        //    // Arrange
        //    var id = 1;
        //    var model = new CustomerCreateModel ("John", "Doe" );
        //    var customerExists = true;

        //    _customerServiceMock.Setup(service => service.CustomerExistsAsync(id))
        //        .ReturnsAsync(customerExists);

        //    // Act
        //    var result = await _controller.UpdateCustomer(id, model);

        //    // Assert
        //    var noContentResult = Assert.IsType<NoContentResult>(result);
        //}

        //[Fact]
        //public async Task DeleteCustomerById_WithValidId_ReturnsNoContentResult()
        //{
        //    // Arrange
        //    var id = 1;

        //    // Act
        //    var result = await _controller.DeleteCustomerById(id);

        //    // Assert
        //    var noContentResult = Assert.IsType<NoContentResult>(result);
        //}

    }
}