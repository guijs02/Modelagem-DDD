using Order.Domain.events;
using Shared.Event;
using Shared.Handlers;

namespace Email.Domain.Handlers
{
    public class SentEmailWhenOrderFinishedHandler : IEventHandler<FinishedOrderEvent>
    {
        public void Handle(FinishedOrderEvent @event)
        {
            // Logic to send email when order is finished
            Console.WriteLine("Email sent for finished order event.");
        }
    }

   
}
