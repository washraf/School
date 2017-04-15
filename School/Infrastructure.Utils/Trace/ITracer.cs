using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Race.Infrastructure.CrossCutting.Utils.Trace
{
    public interface ITracer
    {
        void ConfigureTracer(Type t);
        void LogInfo(string Message);
        void LogError(string msg, Exception e);
        void LogWarning(string msg);



    }
}
