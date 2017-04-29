using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace School.Management.Services.Router
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PremiumService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PremiumService.svc or PremiumService.svc.cs at the Solution Explorer and start debugging.
    public class PremiumService : ICustomerService
    {
        public string AnswerQuestion(string customerName, string question)
        {
            return "Dear Mr." + customerName + "We will answer you righ now";
        }
    }
}
