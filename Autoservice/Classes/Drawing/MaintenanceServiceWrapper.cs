﻿using System;
using System.Collections.Generic;
using Autoservice.Classes.Service;

namespace Autoservice.Classes.Drawing
{
    public class MaintenanceServiceWrapper
    {
        private readonly MaintenanceService service;

        public event Action Event;


        public MaintenanceServiceWrapper(MaintenanceService service)
        {
            this.service = service;
            service.AddHandler(Handler);
        }

        private void Handler()
        {
            Event?.Invoke();
        }

        public IList<string> GetMaintenances()
        {
            return service.GetMaintenances();
        }
        
        ~MaintenanceServiceWrapper()
        {
            service.RemoveHandler(Handler);
        }
    }
}