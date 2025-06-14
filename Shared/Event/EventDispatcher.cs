using Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Event
{
    public class EventDispatcher
    {
        private readonly Dictionary<string, List<IEventHandler<IEvent>>> _eventHandlers = new();

        public void Register<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            var eventName = typeof(TEvent).Name;

            if (!_eventHandlers.ContainsKey(eventName))
            {
                _eventHandlers[eventName] = [];
            }

            _eventHandlers[eventName].Add(new EventHandlerAdapter<TEvent>(handler));
        }

        public void Notify(IEvent @event)
        {
            var eventName = @event.GetType().Name;

            if (_eventHandlers.TryGetValue(eventName, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(@event);
                }
            }
        }
    }
}
