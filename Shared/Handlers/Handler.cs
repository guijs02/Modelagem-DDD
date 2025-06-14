using Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Handlers
{
    public abstract class Handler : IEventHandler<IEvent>
    {
        public void Handle(IEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
