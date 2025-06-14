using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Event
{
    public interface IEventHandler<in T> where T : IEvent
    {
        void Handle(T @event);
    }

    public interface IEvent
    {
        public object EventData { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
