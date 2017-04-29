using System;
using System.Security.Principal;
using System.ServiceModel;
using System.Web.Security;

namespace School.Management.Services.IISHosting.Providers
{
    public class MyRoleProvider : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            var roleNames = new string[] { "Administrators" };

            operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = new GenericPrincipal(operationContext.ServiceSecurityContext.PrimaryIdentity, roleNames);
            return true;
        }
    }
}