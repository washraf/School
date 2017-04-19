using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils.WCF
{ 
    /// <summary>
    /// [FaultContract(typeof(Exception))]
    /// This should be added above all Methods
    /// </summary>
    [ServiceContract]
    public interface IServiceBase:IDisposable
    {
        [OperationContract(IsOneWay = true)]
        void Nothing();
    }
}
