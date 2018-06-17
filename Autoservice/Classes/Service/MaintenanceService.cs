using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using Autoservice.Classes.CarClasses;
using Autoservice.Classes.CarClasses.Details;
using Autoservice.Classes.Drawing;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Service
{
    /// <summary>
    /// Класс сервиса по починке деталей.
    /// </summary>
    public class MaintenanceService : IPositionable
    {
        /// <summary>
        /// Название сервиса.
        /// </summary>
        public string Name { get; }

        private static readonly object locker = new object();

        private bool? paused;
        /// <summary>
        /// Перечень услуг и цен.
        /// </summary>
        private readonly IList<Tuple<Maintenance, int>> maintenances;

        private event Action SomethingUpdated;

        private bool serviceWorking;


        private readonly Thread[] threadWorkers;

        private readonly Queue<Car> inputCarQueue;

        private readonly IList<Car> outputCarList;

        /// <summary>
        /// Конструктор сервиса по починке.
        /// </summary>
        /// <param name="name">Название сервиса.</param>
        /// <param name="workers">Количество потоков, одновременно чинящих автомобили.</param>
        public MaintenanceService(string name, int workers)
        {
            Name = name;
            serviceWorking = true;
            paused = null;

            maintenances = new List<Tuple<Maintenance, int>>();
            threadWorkers = new Thread[workers];
            for (int i = 0; i < workers; i++)
            {
                threadWorkers[i] = new Thread(ServeCar);
            }
            inputCarQueue = new Queue<Car>();
            outputCarList = new List<Car>();
        }

        public void ThreadWork()
        {
            Action<Thread> work = null;
                switch (paused)
                {
                    case true:
                        work = t => t.Resume();
                        paused = false;
                    break;
                    case false:
                        work = t => t.Suspend();
                        paused = true;
                    break;
                    case null:
                        work = t => t.Start();
                        paused = false;
                    break;
                }

            foreach (Thread threadWorker in threadWorkers)
            {
                work?.Invoke(threadWorker);
            }
        }





        public IList<string> GetMaintenances()
        {
            List<string> names = new List<string>();
            lock (locker)
            {
                names.AddRange(maintenances.Select(maintenance =>
                    $"{maintenance.Item1.Name} - {maintenance.Item2} у.е."));
            }

            return names;
        }

        private Car GetCarFromQueue()
        {
            lock (locker)
            {
                if (inputCarQueue.Count <= 0)
                    return null;
                var car = inputCarQueue.Dequeue();
                SomethingUpdated?.Invoke();
                return car;
            }
        }


        private void AddCarToOutput(Car car)
        {
            lock (locker)
            {
                outputCarList.Add(car);
                SomethingUpdated?.Invoke();
            }
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
        public Tuple<bool, string> CheckFlaw(DetailType detail, Significance? significance)
        {
            lock (locker)
            {
                if (significance == null)
                    return Tuple.Create(false, "Все в порядке.");
                var el = maintenances.FirstOrDefault(m => m.Item1.CheckFlaw(detail, (Significance)significance));

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
            while (serviceWorking)
            {
                Car car = GetCarFromQueue();

                if (car == null)
                {
                    Thread.Sleep(100);
                    continue;
                }


                var flaws = car.GetBrokenDetails();

                foreach (Detail detail in flaws)
                {
                    Tuple<Maintenance, int> work;
                    lock (locker)
                    {
                        work = maintenances.FirstOrDefault(w =>
                            w.Item1.CheckFlaw(detail.DetailType, detail.GetFlawSignificance()));
                    }

                    if (work != null)
                    {
                        detail.FixFlaw();
                    }
                }

                AddCarToOutput(car);
            }
            // Вырубает поток
            Thread.CurrentThread.Abort();
        }


        public bool FindCar(Client client)
        {
            lock (locker)
            {
                for (int i = 0; i < outputCarList.Count; i++)
                {
                    if (outputCarList[i] != client.Car)
                        continue;
                    outputCarList.Remove(client.Car);
                    SomethingUpdated?.Invoke();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Добавляет машину в очередь на починку.
        /// </summary>
        /// <param name="car">Машина для починки.</param>
        public void AddCar(Car car)
        {
            lock (locker)
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
            if (paused == true)
                ThreadWork();
        }

        public bool CanFixAtLeastSomething(Car c)
        {
            lock (locker)
                return c.GetBrokenDetails()
                    .Any(detail => maintenances
                        .Any(maintenance => maintenance.Item1.
                            CheckFlaw(detail.DetailType, detail.GetFlawSignificance())));
        }

        public int GetWorkersCount()
        {
            return threadWorkers.Length;
        }

        public Bitmap GetImage()
        {
            return MainFormDrawingManager.GetInstance().GetImage();
        }

        public void AddHandler(Action signal)
        {
            SomethingUpdated += signal;
        }

        public void RemoveHandler(Action signal)
        {
            SomethingUpdated -= signal;
        }
    }
}