using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.Events
{
    public static class DomainEvent
    {
        static DomainEvent()
        {
            Dispatcher = new DefualtEventDispatcher();
        }
        public static IEventDispatcher Dispatcher { get; set; }
        
        public static void Raise<T>(T @event) where T : IDomainEvent
        {
            Dispatcher.Dispatch(@event);
        }

    }
}
