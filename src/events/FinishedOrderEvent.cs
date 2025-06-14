using Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.events
{
    public class FinishedOrderEvent : IEvent
    {
        public object EventData { get; set; }
        public DateTime OccurredOn { get; set; }
        public FinishedOrderEvent(object eventData)
        {
            EventData = eventData;
            OccurredOn = DateTime.UtcNow;
        }

    }
}
