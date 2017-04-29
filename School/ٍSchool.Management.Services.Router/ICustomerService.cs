using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace School.Management.Services.Router
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        string AnswerQuestion(string customerName, string question);
    }
}
