using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.Classes.CarClasses;
using Autoservice.Classes.CarClasses.Details;
using Autoservice.Classes.Drawing;
using Autoservice.Classes.Factories;
using Autoservice.Classes.Service;
using Autoservice.Enums;
using Autoservice.Forms;
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

        private bool threading;
        private static readonly object locker = new object();

        public event Action<List<string>> NewClient;

        /// <summary>
        /// Список фабрик.
        /// </summary>
        private readonly IList<IDetailFactory> factories;

        private readonly MaintenanceFactory mFactory;

        private readonly IList<MaintenanceService> services;

        private readonly ClientNameFactory cnFactory;

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
            cnFactory = new ClientNameFactory();
            rand = new Random(DateTime.Today.Millisecond - 200);
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


        public void ShowClients()
        {
            using (var f = new ClientsForm())
            {
                var rows = 
                    clients.Select(client => 
                        $"Клиент: {client.Name}{(client.ServiceCarIn == null ? "" : $" - Находится в сервисе {client.ServiceCarIn}")}").ToList();
                NewClient?.Invoke(rows);
                f.ShowDialog();
            }
        }


        /// <summary>
        /// Удаляет все сервисы и клиентов.
        /// </summary>
        public void Stop()
        {
            foreach (MaintenanceService maintenanceService in services)
            {
                maintenanceService.Disable(this);
            }
            services.Clear();

            foreach (Client client in clients)
            {
                client.Disable(this);
            }
            clients.Clear();
        }

        public void ShowClient(string name)
        {
            string[] words = name.Split(' ');
            string realName = words[1] + ' ' + words[2];
            foreach (Client client in clients)
            {
                if (client.Name != realName)
                    continue;
                CarFormDrawingManager.GetInstance().AddDrawable(client.Car, -1, -1);
                using (var f = new CarForm())
                {
                    f.ShowDialog();
                }
                return;
            }
        }

        /// <summary>
        /// Добавляет новый сервис.
        /// </summary>
        public MaintenanceService AddService()
        {
            using (var f = new ServiceCreateForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                    return null;
                services.Add(new MaintenanceService(f.ServiceName, f.Workers));
                for (int i = 0; i < f.Offers; i++)
                {
                    services[services.Count - 1].AddMaintenance(mFactory.GetRandomMaintenance());
                }
                return services[services.Count - 1];
            }
        }

        public void ThreadWork()
        {
            foreach (Client client in clients)
            {
                client.ThreadWork();
            }

            foreach (MaintenanceService maintenanceService in services)
            {
                maintenanceService.ThreadWork();
            }
        }


        public void InvokeMaintenanceForm(int pos)
        {
            if (pos == -1 || pos >= services.Count)
                return;

            using (var f = new ServiceForm(new MaintenanceServiceWrapper(services[pos])))
            {
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Возвращает экземпляр Manager.
        /// </summary>
        /// <returns>Возвращает экземпляр Manager.</returns>
        public static Manager GetInstance()
        {
            // Это защита от разрывания потоками.
            lock (locker)
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
        public Car AssembleCar()
        {
            lock (locker)
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

                return new Car(details);
            }
        }

        /// <summary>
        /// Создает клиента.
        /// </summary>
        public int MakeClient()
        {
            clients.Add(new Client(AssembleCar(), cnFactory.GetRandomName()));
            return clients.Count;
        }
        

        /// <summary>
        /// Возвращает случайный сервис.
        /// </summary>
        /// <returns>Возвращает экземпляр MaintenanceService.</returns>
        public MaintenanceService GetRandomService()
        {
            lock (locker)
            {
                Thread.Sleep(20);
                int rnd = rand.Next(0, services.Count * 60);
                int random = rnd / 60;
                return services.Count == 0 ? null : services[random];
            }
        }

    }
}
