using Order.Domain.events;
using Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Domain.entity
{
    public class Order
    {
        private int _id;
        private int _customerId;
        private List<OrderItem> _items;
        private decimal _total;

        public Order(int id, int customerId, List<OrderItem> items)
        {
            _id = id;
            _customerId = customerId;
            _items = items;
            _total = Total();
            Validate();
        }

        public int Id => _id;

        public int CustomerId => _customerId;

        public List<OrderItem> Items => _items;

        private void Validate()
        {
            if (_id == 0)
            {
                throw new Exception("Id is required");
            }

            if (_customerId == 0)
            {
                throw new Exception("CustomerId is required");
            }

            if (_items == null || !_items.Any())
            {
                throw new Exception("Items are required");
            }

            if (_items.Any(item => item.Quantity <= 0))
            {
                throw new Exception("Quantity must be greater than 0");
            }
        }

        public void FinishOrder(EventDispatcher eventDispatcher)
        {
            var finishedOrderEvent = new FinishedOrderEvent(this);
            
            eventDispatcher.Notify(finishedOrderEvent);
        }
        public decimal Total()
        {
            return _items.Sum(item => item.Total());
        }
    }

    public class OrderItem(int id, int quantity, decimal price)
    {
        public int Id { get; private set; } = id;
        public int Quantity { get; private set; } = quantity;
        public decimal Price { get; private set; } = price;

        public decimal Total()
        {
            return Quantity * Price;
        }
    }
}