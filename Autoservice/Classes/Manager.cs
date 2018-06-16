using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autoservice.Classes.Car.Details;
using Autoservice.Classes.Factories;
using Autoservice.Classes.Service;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes
{
    // Синглтон
    /// <summary>
    /// Класс менеджера объектов.
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Экземпляр синглтона Manager.
        /// </summary>
        private static Manager _instance;

        /// <summary>
        /// Список фабрик.
        /// </summary>
        private readonly IList<IDetailFactory> factories;

        private readonly MaintenanceFactory mFactory;

        private readonly IList<MaintenanceService> services;

        private readonly IList<Client> clients;

        private readonly Random rand;

        /// <summary>
        /// Приватный конструктор.
        /// </summary>
        private Manager()
        {
            mFactory = new MaintenanceFactory();
            services = new List<MaintenanceService>();
            clients = new List<Client>();
            rand = new Random(DateTime.Today.Month);
            factories = new List<IDetailFactory>
            {
                new EngineFactory(),
                new BrakesFactory(),
                new ChassisFactory(),
                new ElectronicsFactory(),
                new HullFactory(),
                new InteriorFactory()
            };
        }


        /// <summary>
        /// Удаляет все сервисы.
        /// </summary>
        public void StopServices()
        {
            foreach (MaintenanceService maintenanceService in services)
            {
                maintenanceService.Disable(this);
            }
            services.Clear();
        }

        /// <summary>
        /// Добавляет новый сервис.
        /// </summary>
        /// <param name="name">Название сервиса.</param>
        /// <param name="workers">Количество потоков обработки машин.</param>
        /// <param name="offers">Количество услуг.</param>
        public void AddService(string name, int workers, int offers)
        {
            services.Add(new MaintenanceService(name, workers));
            for (int i = 0; i < offers; i++)
            {
                services[services.Count - 1].AddMaintenance(mFactory.GetRandomMaintenance());
            }
        }


        /// <summary>
        /// Возвращает экземпляр Manager.
        /// </summary>
        /// <returns>Возвращает экземпляр Manager.</returns>
        public static Manager GetInstance()
        {
            // Это защита от разрывания потоками.
            lock (new object())
                // То же самое, что и if (instance == null) 
                // instance = new Manager(); return instance;
                return _instance ?? (_instance = new Manager());
        }

        /// <summary>
        /// Обращается к фабрике и создает деталь.
        /// </summary>
        /// <param name="type">Тип детали.</param>
        /// <returns>Возвращает экземпляр Detail.</returns>
        public Detail CreateDetail(DetailType type)
        {
            return factories.First(fact => fact.DetailType == type).CreateDetail();
        }

        /// <summary>
        /// Собирает машину.
        /// </summary>
        /// <returns>Возвращает экземпляр Car.</returns>
        public Car.Car AssembleCar()
        {
            lock (new object())
            {
                IList<Detail> details = new List<Detail>
                {
                    CreateDetail(DetailType.Engine),
                    CreateDetail(DetailType.Chassis),
                    CreateDetail(DetailType.Electronics),
                    CreateDetail(DetailType.Hull),
                    CreateDetail(DetailType.Interior),
                    CreateDetail(DetailType.Brakes)
                };

                return new Car.Car(details);
            }
        }

        /// <summary>
        /// Создает клиента.
        /// </summary>
        public void MakeClient()
        {
            clients.Add(new Client(AssembleCar()));
        }


        /// <summary>
        /// Возвращает случайный сервис.
        /// </summary>
        /// <returns>Возвращает экземпляр MaintenanceService.</returns>
        public MaintenanceService GetRandomService()
        {
            lock (new object())
            {
                Thread.Sleep(20);
                int random = rand.Next(0, services.Count * 10) / 10;
                return services[random];
            }
        }

    }
}
