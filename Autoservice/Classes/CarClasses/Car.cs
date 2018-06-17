using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using Autoservice.Classes.CarClasses.Details;
using Autoservice.Classes.Drawing;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.CarClasses
{
    public class Car : IPositionable
    {
        /// <summary>
        /// Список деталей автомобиля.
        /// </summary>
        private readonly IList<Detail> details;
        protected static Random R = new Random(DateTime.UtcNow.Millisecond + 700);
        private static readonly object locker = new object();

        private bool? paused;

        private int counter;

        /// <summary>
        /// Работает ли машина.
        /// </summary>
        public bool IsWorking { get; set; }

        private readonly Thread carThread;


        private bool isEnabled;

        public Car(IList<Detail> details)
        {
            this.details = details;
            carThread = new Thread(CarWork);
            IsWorking = true;
            isEnabled = true;
        }
        protected static int GetRandom(int max)
        {
            lock (locker)
            {
                // Подождать 20 мс., чтобы рандом был настоящим.
                Thread.Sleep(20);
                return R.Next(0, max);
            }
        }

        public void ThreadWork()
        {
            switch (paused)
            {
                case true:
                    carThread.Resume();
                    paused = false;
                    break;
                case false:
                    carThread.Suspend();
                    paused = true;
                    break;
                case null:
                    carThread.Start();
                    paused = false;
                    break;
            }
        }

        /// <summary>
        /// Проверяет, есть ли в машине какие-либо поломки.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool HasFlaws()
        {
            // То же самое, что и foreach (var d in details) if(d.HasFlaws()) return true;
            return details.Any(detail => detail.HasFlaw());
        }

        public void AddHandler(Action signal)
        {
            foreach (Detail detail in details)
            {
                detail.SomethingChanged += signal;
            }
        }

        public void RemoveHandler(Action signal)
        {
            foreach (Detail detail in details)
            {
                detail.SomethingChanged -= signal;
            }
        }

        /// <summary>
        /// Выдает список сломанных деталей.
        /// </summary>
        /// <returns>Возвращает экземпляр IList с Detail</returns>
        public IList<Detail> GetBrokenDetails(bool all = false)
        {
            return all ? details : details.Where(detail => detail.HasFlaw()).ToList();
            // То же самое, что и foreach цикл с допсписком
        }

        private void CarWork()
        {
            while (isEnabled)
            {
                Thread.Sleep(500);
                if (!IsWorking)
                    continue;
                if (counter-- > 0)
                    continue;

                int det = GetRandom(600) / 100;

                if (!details[det].TrySetRandomFlaw())
                    continue;
                counter = 15;

            }

            carThread.Abort();
        }

        public void Disable(Client c)
        {
            isEnabled = false;
            if (paused == true)
                ThreadWork();
        }

        public Bitmap GetImage()
        {
            return CarFormDrawingManager.GetInstance().GetImage();
        }
    }
}