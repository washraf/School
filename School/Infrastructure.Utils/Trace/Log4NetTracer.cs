using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Infrastructure.Utils.Trace
{

    [Export(typeof(ITracer))]
    public class Log4NetTracer:ITracer
    {
        private ILog currentLogger;
        static Log4NetTracer()
        {
            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "%date [%thread] %-5level %logger [%ndc] - %message%newline";
            layout.ActivateOptions();
            FileAppender appender = new FileAppender();
            appender.File = "Application.txt";
            //ConsoleAppender appender = new ConsoleAppender();
            appender.Layout = layout;
            appender.ActivateOptions();

            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            Logger root = hierarchy.Root;
            root.Level = log4net.Core.Level.All;
            BasicConfigurator.Configure(appender);
            log4net.Config.BasicConfigurator.Configure();   
        }

        public void ConfigureTracer(Type t)
        {
            currentLogger =  log4net.LogManager.GetLogger(t);
        }

        public void LogInfo(string info)
        {
           // currentLogger.Info(info);
        }

        public void LogError(string msg, Exception e)
        {
            //currentLogger.Error(msg,e);
        }

        public void LogWarning(string msg)
        {
            //currentLogger.Warn(msg);
        }
    }
}
