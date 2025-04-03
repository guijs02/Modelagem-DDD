using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.entity;

namespace src.services
{
    public class OrderService
    {
        public static decimal ApplyDiscountAccordingToRegionCustomer(Customer customer, Order order)
        {
            if(customer.Address.State == "SP")
            {
                return order.Total() / 2; // 10% discount for SP region
            }
            else if (customer.Address.State == "RJ")
            {
                return order.Total() * 0.10m; // 5% discount for RJ region
            }
            else
            {
                return order.Total(); // No discount for other regions
            }
        }
    }
}