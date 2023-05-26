using Customer.MicroService.Models;

namespace Customer.MicroService.UnitTests
{
    public class CustomerReadModelTests
    {
        [Fact]
        public void CustomerReadModel_Constructor_Should_Initialize_FullName()
        {
            // Arrange
            var model = new CustomerReadModel(1, "John", "Doe");

            // Act

            // Assert
            Assert.True(model.FullName == "John Doe");
        }

        [Fact]
        public void CustomerReadModel_Id_Assignment()
        {
            // Arrange
            var model = new CustomerReadModel(1, "John", "Doe");

            // Act

            // Assert
            Assert.True(model.Id == 1);
        }

        [Fact]
        public void CustomerReadModel_FirstName_Assignment()
        {
            // Arrange
            var model = new CustomerReadModel(1, "John", "Doe");

            // Act

            // Assert
            Assert.True(model.FirstName == "John");
        }

        [Fact]
        public void CustomerReadModel_LastName_Assignment()
        {
            // Arrange
            var model = new CustomerReadModel(1, "John", "Doe");

            // Act

            // Assert
            Assert.True(model.LastName == "Doe");
        }
    }
}
