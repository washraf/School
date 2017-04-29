using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace School.Management.Services.Router
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NormalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NormalService.svc or NormalService.svc.cs at the Solution Explorer and start debugging.
    public class NormalService : ICustomerService
    {
        public string AnswerQuestion(string customerName, string question)
        {
            return "Hello " + customerName + " we will never call you back";
        }
    }
}
