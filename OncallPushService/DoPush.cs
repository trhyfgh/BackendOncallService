using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using Common.Logging;

namespace OncalTimePush
{
    public class DoPush:IJob
    {
        //private static ILog onCallLog = LogManager.GetLogger(typeof(OntimePush));
        
        private static readonly ILog pushLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Execute(IJobExecutionContext context)
        {
            //add push logic in this part
        }
    }
   
}