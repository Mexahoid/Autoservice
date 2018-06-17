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

        public void Start()
        {
            carThread.Start();
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
                if (counter-- > 0)
                    continue;
                foreach (Detail detail in details)
                {
                    if (!detail.TrySetRandomFlaw())
                        continue;
                    counter = 15;
                    break;
                }
            }

            carThread.Abort();
        }

        public void Disable(Client c)
        {
            isEnabled = false;
        }

        public Bitmap GetImage()
        {
            return CarFormDrawingManager.GetInstance().GetImage();
        }
    }
}