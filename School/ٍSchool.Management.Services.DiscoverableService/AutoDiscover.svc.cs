using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using School.Management.Services.DiscoverableService;

namespace School.Management.Services.DiscoverableService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AutoDiscover" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AutoDiscover.svc or AutoDiscover.svc.cs at the Solution Explorer and start debugging.
    public class AutoDiscover : IAutoDiscover
    {
        public string GetMyName()
        {
            return  ServiceSecurityContext.Current.WindowsIdentity.Name;
        }
    }
}
