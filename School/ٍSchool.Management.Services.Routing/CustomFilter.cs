using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace School.Management.Services.Routing
{
    public class CustomFitler : MessageFilter
    {
        public CustomFitler(string filterData)
        {

        }

        public override bool Match(MessageBuffer buffer)
        {
            return true;
        }

        public override bool Match(Message message)
        {
            if (message.ToString().IndexOf("walid") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}