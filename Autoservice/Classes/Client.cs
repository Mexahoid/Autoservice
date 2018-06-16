using System;
using System.Collections.Generic;
using System.Threading;
using Autoservice.Classes.Car.Details;
using Autoservice.Classes.Service;

namespace Autoservice.Classes
{
    public class Client
    {
        public Car.Car Car { get; }

        private readonly Thread clientThread;
        private int treshold;
        private bool clientActive;

        public Client(Car.Car car)
        {
            Car = car;
            clientThread = new Thread(Act);
            Random r = new Random(DateTime.Now.Date.DayOfYear + 100);
            Thread.Sleep(20);
            treshold = r.Next(0, 70) / 10 + 1;
            clientThread.Start();
            clientActive = true;
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


                    var list = Car.GetBrokenDetails();

                    if (list.Count < treshold)
                        continue;

                    bool canBeFixed = false;
                    service = Manager.GetInstance().GetRandomService();
                    foreach (Detail detail in list)
                    {
                        if (service.CheckFlaw(detail.DetailType, detail.GetFlawSignificance()).Item1)
                            canBeFixed = true;
                    }

                    if (!canBeFixed)
                        continue;
                    service.AddCar(Car);
                    Car.IsWorking = false;
                }
                else
                {
                    Thread.Sleep(1000);
                    if (service == null)
                        continue;
                    if (service.FindCar(this))
                    {
                        Car.IsWorking = true;
                    }
                }

            }
            clientThread.Abort();
        }

        public void Disable(Manager m)
        {
            clientActive = false;
            Car.Disable(this);
        }
    }
}