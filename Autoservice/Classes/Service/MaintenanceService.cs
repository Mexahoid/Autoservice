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

        /// <summary>
        /// Перечень услуг и цен.
        /// </summary>
        private readonly IList<Tuple<Maintenance, int>> maintenances;

        private event Action SomethingUpdated;

        private bool serviceWorking;


        private readonly Thread[] threadWorkers;

        private readonly ConcurrentQueue<Car> inputCarQueue;

        private readonly IList<Car> workingCarList;

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
            
            workingCarList = new List<Car>();
            maintenances = new List<Tuple<Maintenance, int>>();
            threadWorkers = new Thread[workers];
            for (int i = 0; i < workers; i++)
            {
                threadWorkers[i] = new Thread(ServeCar);
            }
            inputCarQueue = new ConcurrentQueue<Car>();
            outputCarList = new List<Car>();
        }

        public void Start()
        {
            foreach (Thread threadWorker in threadWorkers)
            {
                threadWorker.Start();
            }
        }





        public IList<string> GetMaintenances()
        {
            List<string> names = new List<string>();
            lock (new object())
            {
                names.AddRange(maintenances.Select(maintenance =>
                    $"{maintenance.Item1.Name} - {maintenance.Item2} у.е."));
            }

            return names;
        }

        public IList<string> GetWorkingCars()
        {
            List<string> names = new List<string>();
            lock (new object())
            {
                names.AddRange(from car in workingCarList where car != null select car.ClientName);
            }

            return names;
        }

        private Car GetCarFromQueue()
        {
            lock (new object())
            {
                if (inputCarQueue.Count <= 0)
                    return null;

                if (!inputCarQueue.TryDequeue(out Car outer))
                    return null;
                inputCarQueueString.TryDequeue(out string name);

                Action<ConcurrentQueue<Car>> act = (q => inputCarQueue.TryDequeue(out Car s));
                

                workingCarList.Add(outer);
                SomethingUpdated?.Invoke();
                return outer;
            }
        }
        

        private void AccessInputQueue(Action<ConcurrentQueue<Car>> action)
        {
            lock (new object())
            {
                action(inputCarQueue);
            }
        }

        private void AccessWorkingCarList(Action<IList<Car>> action)
        {
            lock (new object())
            {
                action(workingCarList);
            }
        }

        private void AccessOutputCarList(Action<IList<Car>> action)
        {
            lock (new object())
            {
                action(outputCarList);
            }
        }








        private void AddCarToOutput(Car car)
        {
            lock (new object())
            {
                if (workingCarList.Contains(car))
                    workingCarList.Remove(car);
                outputCarList.Add(car);
                SomethingUpdated?.Invoke();
            }
        }

        public IList<string> GetInQueueCars()
        {
            IList<string> cars = new List<string>();
            for (int i = 0; i < inputCarQueueString.Count; i++)
            {
                string carHolder;
                do
                    inputCarQueueString.TryDequeue(out carHolder);
                while (carHolder == null);

                cars.Add(carHolder);

                inputCarQueueString.Enqueue(carHolder);
            }
            return cars;
        }

        public IList<string> GetOutQueueCars()
        {
            var cars = new List<string>();

            lock (new object())
            {
                cars.AddRange(outputCarList.Select(car => car.ClientName));
            }

            return cars;
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

                AddCarToOutput(car);
            }
            // Вырубает поток
            Thread.CurrentThread.Abort();
        }

        private void RemoveFromList(Car car)
        {
            lock (new object())
            {
                workingCarList.Remove(car);
            }
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
            lock (new object())
            {
                inputCarQueue.Enqueue(car);
                inputCarQueueString.Enqueue(car.ClientName);
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