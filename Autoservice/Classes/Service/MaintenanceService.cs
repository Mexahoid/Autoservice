using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Autoservice.Classes.Car.Details;
using Autoservice.Enums;

namespace Autoservice.Classes.Service
{
    /// <summary>
    /// Класс сервиса по починке деталей.
    /// </summary>
    public class MaintenanceService
    {
        /// <summary>
        /// Название сервиса.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Перечень услуг и цен.
        /// </summary>
        private readonly IList<Tuple<Maintenance, int>> maintenances;

        private bool serviceWorking;


        private readonly Thread[] threadWorkers;

        private readonly Queue<Car.Car> inputCarQueue;

        private readonly IList<Car.Car> outputCarList;

        /// <summary>
        /// Конструктор сервиса по починке.
        /// </summary>
        /// <param name="name">Название сервиса.</param>
        /// <param name="workers">Количество потоков, одновременно чинящих автомобили.</param>
        public MaintenanceService(string name, int workers)
        {
            Name = name;
            serviceWorking = true;
            maintenances = new List<Tuple<Maintenance, int>>();
            threadWorkers = new Thread[workers];
            for (int i = 0; i < workers; i++)
            {
                threadWorkers[i] = new Thread(ServeCar);
                threadWorkers[i].Start();
            }
            inputCarQueue = new Queue<Car.Car>();
            outputCarList = new List<Car.Car>();
        }

        /// <summary>
        /// Добавление услуг в перечень.
        /// </summary>
        /// <param name="maintenance">Кортеж из услуги и цены.</param>
        public void AddMaintenance(Tuple<Maintenance, int> maintenance)
        {
            maintenances.Add(maintenance);
        }

        /// <summary>
        /// Проверка возможностей сервиса по починке.
        /// </summary>
        /// <param name="detail">Тип детали.</param>
        /// <param name="significance">Степень поломки.</param>
        /// <returns>Возвращает кортеж из логического значения и строки.</returns>
        public Tuple<bool, string> CheckFlaw(DetailType detail, Significance significance)
        {
            lock (new object())
            {
                var el = maintenances.FirstOrDefault(m => m.Item1.CheckFlaw(detail, significance));

                if (el == null)
                    return Tuple.Create(false, "Такие поломки здесь не чинятся.");
                return Tuple.Create(true,
                    $"Да, мы можем это починить, услуга: {el.Item1.Name}, цена: {el.Item2}.");
            }
        }

        /// <summary>
        /// Обработать машину.
        /// </summary>
        private void ServeCar()
        {
            Car.Car car = null;
            while (serviceWorking)
            {
                lock (new object())
                {
                    if (inputCarQueue.Count > 0)
                        car = inputCarQueue.Dequeue();
                }

                if (car == null)
                {
                    Thread.Sleep(100);
                    continue;
                }


                var flaws = car.GetBrokenDetails();

                foreach (Detail detail in flaws)
                {
                    Tuple<Maintenance, int> work;
                    lock (new object())
                    {
                        work = maintenances.FirstOrDefault(w =>
                            w.Item1.CheckFlaw(detail.DetailType, detail.GetFlawSignificance()));
                    }

                    if (work != null)
                    {
                        detail.FixFlaw();
                    }
                }

                lock (new object())
                {
                    outputCarList.Add(car);
                }
            }
            // Вырубает поток
            Thread.CurrentThread.Abort();
        }

        public bool FindCar(Client client)
        {
            lock (new object())
            {
                for (int i = 0; i < outputCarList.Count; i++)
                {
                    if (outputCarList[i] != client.Car)
                        continue;
                    outputCarList.RemoveAt(i);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Добавляет машину в очередь на починку.
        /// </summary>
        /// <param name="car">Машина для починки.</param>
        public void AddCar(Car.Car car)
        {
            lock (new object())
            {
                inputCarQueue.Enqueue(car);
            }
        }

        /// <summary>
        /// Отключает потоки.
        /// </summary>
        /// <param name="m">Экземпляр менеджера.</param>
        public void Disable(Manager m)
        {
            serviceWorking = false;
        }
    }
}