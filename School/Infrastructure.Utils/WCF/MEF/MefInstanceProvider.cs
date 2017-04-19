//===================================================================================
// Written by thangit@yahoo.com
//===================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace Infrastructure.Utils.WCF.MEF
{
    public class MefInstanceProvider : IInstanceProvider
    {
        #region Fields

        readonly Type serviceContractType;
        private static CompositionContainer Container { get; set; } 

        #endregion

        #region Constructors

        static MefInstanceProvider()
        {
            Compose();
        }

        public MefInstanceProvider(Type t)
        {
            
            if (t!= null && !t.IsInterface)
            {
                throw new ArgumentException("Specified Type must be an interface");
            }

            serviceContractType = t;
        }

        #endregion

        #region IInstanceProvider Members

        public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            if (serviceContractType != null)
            {
                ImportDefinition importDefinition = new ImportDefinition(i => i.ContractName.Equals(serviceContractType.FullName), serviceContractType.FullName, ImportCardinality.ZeroOrMore, false, false);
                AtomicComposition atomicComposition = new AtomicComposition();
                IEnumerable<Export> extensions = null;

                bool exportDiscovery = Container.TryGetExports(importDefinition, atomicComposition, out extensions);

                if (extensions != null && extensions.Count<Export>() > 0)
                {
                    return extensions.First().Value;
                }                
            }

            return null;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            IDisposable disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        #endregion

        #region Private Methods

        private static void Compose()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(@".\bin","*.dll")); //Extensions
            Container = new CompositionContainer(catalog);
        }

        #endregion
    }
}
