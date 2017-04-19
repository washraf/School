using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.Events
{
    public class DefualtEventDispatcher:IEventDispatcher
    {
        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            var type = typeof(IDomainHandler<TEvent>);

            List<Assembly> allAssemblies = new List<Assembly>();
            string path = Path.GetDirectoryName
                (Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));

            List<Type> handlers = new List<Type>();
            foreach (var assembly in allAssemblies)
            {
                handlers.AddRange(
                    assembly.DefinedTypes
                        .Where(mytype => mytype.GetInterfaces().Contains(type)));
            }
            foreach (var handler in handlers)
            {
                var concretehandler =  Activator.CreateInstance(handler) as IDomainHandler<TEvent>;
                concretehandler.Handle(eventToDispatch);
            }
        }
    }
}
