using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Quartz.Impl;
using Quartz;

namespace OncallPushService
{
    public partial class ScheduleManage : ServiceBase
    {
        private readonly ILog scheduleLoger;
        private IScheduler scheduler;

        public ScheduleManage()
        {
            InitializeComponent();
            scheduleLoger = LogManager.GetLogger(GetType());
            ISchedulerFactory pushSchedulerfactory = new StdSchedulerFactory();
            scheduler = pushSchedulerfactory.GetScheduler();
        }


        protected override void OnStart(string[] args)
        {
            scheduler.Start();
            scheduleLoger.Info("-------------------scheduler start----------------------");
        }

        protected override void OnStop()
        {
            scheduler.Shutdown();
            scheduleLoger.Info("-------------------scheduler stop-----------------------");
            
        }
    }
}
