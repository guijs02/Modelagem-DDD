using Shared.Event;

namespace Shared.Event
{
    public class EventHandlerAdapter<TEvent> : IEventHandler<IEvent> where TEvent : IEvent
    {
        private readonly IEventHandler<TEvent> _innerHandler;

        public EventHandlerAdapter(IEventHandler<TEvent> innerHandler)
        {
            _innerHandler = innerHandler;
        }

        public void Handle(IEvent @event)
        {
            _innerHandler.Handle((TEvent)@event);
        }
    }
}
