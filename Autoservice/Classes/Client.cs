using System;
using System.Collections.Generic;
using System.Threading;
using Autoservice.Classes.CarClasses;
using Autoservice.Classes.CarClasses.Details;
using Autoservice.Classes.Service;

namespace Autoservice.Classes
{
    public class Client
    {
        public Car Car { get; }
        public string Name { get; }

        private bool? paused;

        public string ServiceCarIn { get; set; }

        private readonly Thread clientThread;
        private event Action SomethingChanged;
        private bool clientActive;

        public Client(Car car, string name, Action handlerAction)
        {
            Car = car;
            Name = name;
            SomethingChanged += handlerAction;
            paused = null;
            clientThread = new Thread(Act);
            var r = new Random(DateTime.Now.Date.DayOfYear + 100);
            Thread.Sleep(20);
            //treshold = r.Next(0, 70) / 10 + 1;
            clientActive = true;
        }

        public void ThreadWork()
        {
            switch (paused)
            {
                case true:
                    clientThread.Resume();
                    paused = false;
                    break;
                case false:
                    clientThread.Suspend();
                    paused = true;
                    break;
                case null:
                    clientThread.Start();
                    paused = false;
                    break;
            }
            Car.ThreadWork();
        }

        private void Act()
        {
            MaintenanceService service = null;
            while (clientActive)
            {
                if(Car.IsWorking)
                {
                    if (!Car.HasFlaws())
                    {
                        Thread.Sleep(1000);
                        continue;
                    }


                    //var list = Car.GetBrokenDetails();
                    Thread.Sleep(1000);

                    //if (list.Count < treshold)
                    //    continue;
                    
                    service = Manager.GetInstance().GetRandomService();
                    if (service == null)
                        continue;

                    
                    if (!service.CanFixAtLeastSomething(Car))
                        continue;
                    ServiceCarIn = service.Name;
                    Car.IsWorking = false;
                    service.AddCar(Car);
                    SomethingChanged?.Invoke();
                    
                }
                else
                {
                    Thread.Sleep(1000);
                    if (service == null)
                        continue;
                    if (!service.FindCar(this))
                        continue;
                    Car.IsWorking = true;
                    ServiceCarIn = null;
                }

            }
            clientThread.Abort();
        }

        public void Disable(Manager m)
        {
            clientActive = false;
            if(paused == true)
                ThreadWork();
            Car.Disable(this);
        }
    }
}