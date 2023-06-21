using AutoMapper;
using Customer.MicroService.Controllers;
using Customer.MicroService.Entities;
using Customer.MicroService.Models;
using Customer.MicroService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Customer.MicroService.UnitTests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomerService> _customerServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<CustomersController>> _loggerMock;
        private readonly CustomersController _controller;

        public CustomersControllerTests()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<CustomersController>>();
            _controller = new CustomersController(
                _customerServiceMock.Object,
                _mapperMock.Object,
                _loggerMock.Object
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