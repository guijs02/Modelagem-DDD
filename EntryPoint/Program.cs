using Domain.entity;
using Email.Domain.Handlers;
using Order.Domain.entity;
using Order.Domain.events;
using Shared.Event;

namespace EntryPoint
{
    public class Program
    {
        static void Main(string[] args)
        {
            var eventDispatcher = new EventDispatcher();
            IEvent @event = new FinishedOrderEvent("");

            var eventHandler = new SentEmailWhenOrderFinishedHandler();

            eventDispatcher.Register(eventHandler);

            var orderItem = new OrderItem(1, 40, 300m);
            var items = new List<OrderItem>() { orderItem };

            Order.Domain.entity.Order order = new (1, 3, items);

            order.FinishOrder(eventDispatcher);
        }
    }
}
