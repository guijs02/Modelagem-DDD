using Domain.entity;
using Xunit;

namespace test
{
    public class CustomerTest
    {
        [Fact]
        public void ShouldCreateCustomerWithSuccess()
        {
            // Arrange
            var address = new Address("123 Main St", "Anytown", "CA", "12345");
            var customer = new Customer(1, "John Doe", "30", address);

            // Assert
            Assert.Equal(1, customer.Id);
            Assert.Equal("John Doe", customer.Name);
            Assert.Equal("30", customer.Age);
            Assert.True(customer.Address.Equals(address));

            customer.UpdateName("Jane Doe");
            customer.UpdateAge("31");

            Assert.Equal("Jane Doe", customer.Name);
            Assert.Equal("31", customer.Age);
        }

        [Fact]
        public void ShouldNotCreateCustomerWithInvalidFields()
        {
            // Arrange
            var address = new Address("123 Main St", "Anytown", "CA", "12345");

            // Assert
            Assert.Throws<Exception>(() => new Customer(1, "", "30", address));
            Assert.Throws<Exception>(() => new Customer(1, "John Doe", "", address));
            Assert.Throws<Exception>(() => new Customer(0, "John Doe", "", address));
        }

        [Fact]
        public void ShouldNotCreateAddressWithInvalidFields()
        {
            // Arrange
            // Assert
            Assert.Throws<Exception>(() => new Address("", "Anytown", "CA", "12345"));
            Assert.Throws<Exception>(() => new Address("123 Main St", "", "CA", "12345"));
            Assert.Throws<Exception>(() => new Address("123 Main St", "Anytown", "", "12345"));
            Assert.Throws<Exception>(() => new Address("123 Main St", "Anytown", "CA", ""));
        }
    }

}