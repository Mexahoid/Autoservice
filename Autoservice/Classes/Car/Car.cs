using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Autoservice.Classes.Car.Details;
using Autoservice.Enums;

namespace Autoservice.Classes.Car
{
    public class Car
    {
        /// <summary>
        /// Список деталей автомобиля.
        /// </summary>
        private readonly IList<Detail> details;

        /// <summary>
        /// Работает ли машина.
        /// </summary>
        public bool IsWorking { get; set; }

        private Thread carThread;

        private bool isEnabled;

        public Car(IList<Detail> details)
        {
            this.details = details;
            carThread = new Thread(CarWork);
            carThread.Start();
            IsWorking = true;
            isEnabled = true;
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

        /// <summary>
        /// Выдает список сломанных деталей.
        /// </summary>
        /// <returns>Возвращает экземпляр IList с Detail</returns>
        public IList<Detail> GetBrokenDetails()
        {
            // То же самое, что и foreach цикл с допсписком
            return details.Where(detail => detail.HasFlaw()).ToList();
        }

        private void CarWork()
        {
            while (isEnabled)
            {
                Thread.Sleep(1000);
                foreach (Detail detail in details)
                {
                    detail.TrySetRandomFlaw();
                }
            }

            carThread.Abort();
        }

        public void Disable(Client c)
        {
            isEnabled = false;
        }
    }
}