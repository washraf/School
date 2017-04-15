using System;
using System.ComponentModel.Composition;
using System.Security.Permissions;
using System.ServiceModel;
using System.Transactions;

using Race.Infrastructure.CrossCutting.Utils.Trace;
using Race.Infrastructure.CrossCutting.Utils.WCF.MEF;

namespace Race.Infrastructure.CrossCutting.Utils.WCF
{
    /// <summary>
    /// <attribute name="MefBehavior">
    /// MefBehavior: Allow the Serive to be created via my updated MefInstanceProvider
    /// </attribute>
    /// <attribute name="PartCreationPolicy">
    /// PartCreationPolicy: Allow the Serive instance to be created each time with a new request (Not needed But I like explicitness)
    /// </attribute>
    /// <attribute name="ServiceBehavior">
    /// ServiceBehavior: Default Service eBehavior Tag
    /// InstanceContextMode.PerCall : Allow new instance for every new call even from same host
    /// ConcurrencyMode = ConcurrencyMode.Multiple : allow multiple calls for same host (For Asp Clients)
    /// </attribute>
    /// </summary>
    [MefBehavior]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public abstract class ServiceBase:IServiceBase
    {
        protected ITracer _tracer;

        public ServiceBase(ITracer tracer)
        {
            if (tracer == (ITracer)null)
                throw new ArgumentNullException("tracer", "Tracer Should Not Be Null");
            this._tracer = tracer;

        }
       
        [OperationBehavior(TransactionScopeRequired = true)]
        [PrincipalPermission(SecurityAction.Demand,Role = @"Start\Walid")]
        protected virtual T ExecuteTransactional<T>(Func<T> codetoExecute)
        {
            try
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                //    var r = codetoExecute.Invoke();
                //    scope.Complete();//Ew3a Tensa
                //    return r;
                //}
                return codetoExecute.Invoke();
            }
            catch (Exception ex)
            {
                this._tracer.LogError(ex.Message,ex);
                throw new FaultException<Exception>(ex, ex.Message);
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Name = @"Start\Walid")]
        protected virtual T ExecuteNonTransactional<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (Exception ex)
            {
                this._tracer.LogError(ex.Message, ex);
                throw new FaultException<Exception>(ex, ex.Message);
            }
        }

        public virtual void Dispose()
        {
            
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void Nothing()
        {
           
        }
    }
}
