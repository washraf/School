using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Race.Infrastructure.CrossCutting.Utils.Trace;

namespace Race.Infrastructure.CrossCutting.Utils.Application
{
    public class ApplicationBase
    {
        protected ITracer _tracer;

        public ApplicationBase(ITracer tracer)
        {
            if (tracer == (ITracer)null)
                throw new ArgumentNullException("tracer", "Tracer Should Not Be Null");
            this._tracer = tracer;

        }

        protected virtual T ExecuteTransactional<T>(Func<T> codetoExecute)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var r = codetoExecute.Invoke();
                    scope.Complete();//Ew3a Tensa
                    return r;
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _tracer.LogError($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}",dbEx);
                    }
                }
                throw dbEx;
            }
            catch (Exception ex)
            {
                this._tracer.LogError(ex.Message, ex);
                throw ex;
            }
        }

        protected virtual T ExecuteNonTransactional<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _tracer.LogError($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}", dbEx);
                    }
                }
                throw dbEx;
            }
            catch (Exception ex)
            {
                this._tracer.LogError(ex.Message, ex);
                throw ex;
            }
        }

    }
}
