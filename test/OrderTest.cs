using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.entity;
using src.services;
using Xunit;


namespace test
{
    public class OrderTest
    {
        [Fact]
        public void ShouldApplyDiscountCorrectAccordingToRegions_SP_AND_RJ()
        {
            var address = new Address("123 Main St", "Anytown", "SP", "12345");
            var customer = new Customer(1, "John Doe", "30", address);

            var items = new List<OrderItem>
            {
                new OrderItem(1, 1, 10),
                new OrderItem(2, 1, 20)
            };
                
            var order = new Order(1, customer.Id, items);

            var result = OrderService.ApplyDiscountAccordingToRegionCustomer(customer, order);

            Assert.Equal(15, result); 


            var address2 = new Address("123 Main St", "Anytown", "RJ", "12345");
            var customer2 = new Customer(1, "John Doe", "30", address2);

            var items2 = new List<OrderItem>
            {
                new OrderItem(1, 1, 10),
                new OrderItem(2, 1, 40)
            };
                
            var order2 = new Order(1, customer2.Id, items2);

            var result2 = OrderService.ApplyDiscountAccordingToRegionCustomer(customer2, order2);

            Assert.Equal(5, result2); 
           
            // Given
        
            // When
        
            // Then
        }
    }
}