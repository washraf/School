using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace School.Management.Services.IISHosting.Providers
{
    public class MyMemberShipProvider: UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            
        }
    }
}