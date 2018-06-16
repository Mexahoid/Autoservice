using System;
using System.Collections.Generic;
using System.Threading;
using Autoservice.Classes.Service;
using Autoservice.Enums;

namespace Autoservice.Classes.Factories
{
    /// <summary>
    /// Класс для хранения названий услуг.
    /// </summary>
    public sealed class MaintenanceFactory
    {
        private readonly IDictionary<Tuple<DetailType, Significance>, string> dictionary;

        private readonly Random rand;

        public MaintenanceFactory()
        {
            dictionary = new Dictionary<Tuple<DetailType, Significance>, string>();

            rand = new Random(DateTime.UtcNow.Minute + GetHashCode());

            InitMinorMaintetances();
            InitAverageMaintetances();
            InitSeriousMaintetances();
            InitCriticalMaintetances();
            InitFatalMaintetances();
        }

        /// <summary>
        /// Выдает случайную цену на услугу.
        /// </summary>
        /// <param name="detail">Деталь для починки.</param>
        /// <param name="significance">Степень поломки.</param>
        /// <returns></returns>
        private int GetRandomMaintenanceCost(DetailType detail, Significance significance)
        {
            int cost = -1;
            while (cost < 0)
            {
                Thread.Sleep(20);
                cost = (int)significance / 20 * (int)detail + rand.Next(-10, 10) * 200;
            }
            return cost;
        }

        /// <summary>
        /// Метод, выдающий случайную услугу со случайной для нее ценой.
        /// </summary>
        /// <returns>Возвращает кортеж из Maintenance и целочисленного значения.</returns>
        public Tuple<Maintenance, int> GetRandomMaintenance()
        {
            Thread.Sleep(20);
            var keys = dictionary.Keys;
            int randPos = rand.Next(0, keys.Count * 10) / 10;
            var enumerator = keys.GetEnumerator();
            int i = 0;
            while (i++ < randPos)
                enumerator.MoveNext();
            var tuple = enumerator.Current;
            enumerator.Dispose();
            return Tuple.Create(new Maintenance(
                dictionary[tuple ?? throw new InvalidOperationException()],
                tuple.Item1,
                tuple.Item2), GetRandomMaintenanceCost(tuple.Item1, tuple.Item2));
        }


        private void InitMinorMaintetances()
        {
            dictionary.Add(Tuple.Create(DetailType.Brakes, Significance.Minor), "Замена тормозной жидкости");
            dictionary.Add(Tuple.Create(DetailType.Chassis, Significance.Minor), "Диагностика ходовой части");
            dictionary.Add(Tuple.Create(DetailType.Electronics, Significance.Minor), "Диагностика электроники");
            dictionary.Add(Tuple.Create(DetailType.Engine, Significance.Minor), "Замена масла");
            dictionary.Add(Tuple.Create(DetailType.Hull, Significance.Minor), "Полировка корпуса");
            dictionary.Add(Tuple.Create(DetailType.Interior, Significance.Minor), "Очистка салона");
        }
        private void InitAverageMaintetances()
        {
            dictionary.Add(Tuple.Create(DetailType.Brakes, Significance.Average), "Смена тормозных колодок");
            dictionary.Add(Tuple.Create(DetailType.Chassis, Significance.Average), "Подкачка колес");
            dictionary.Add(Tuple.Create(DetailType.Electronics, Significance.Average), "Замена сигнализации");
            dictionary.Add(Tuple.Create(DetailType.Engine, Significance.Average), "Замена свечей зажигания");
            dictionary.Add(Tuple.Create(DetailType.Hull, Significance.Average), "Выправление помятых участков");
            dictionary.Add(Tuple.Create(DetailType.Interior, Significance.Average), "Перетяжка обшивки");
        }
        private void InitSeriousMaintetances()
        {
            dictionary.Add(Tuple.Create(DetailType.Brakes, Significance.Serious), "Восстановление тормозных дисков");
            dictionary.Add(Tuple.Create(DetailType.Chassis, Significance.Serious), "Замена колес");
            dictionary.Add(Tuple.Create(DetailType.Electronics, Significance.Serious), "Восстановление кабелей электроники");
            dictionary.Add(Tuple.Create(DetailType.Engine, Significance.Serious), "Замена системы подачи топлива");
            dictionary.Add(Tuple.Create(DetailType.Hull, Significance.Serious), "Замена стекол");
            dictionary.Add(Tuple.Create(DetailType.Interior, Significance.Serious), "Смена обшивки и наполнителя");
        }
        private void InitCriticalMaintetances()
        {
            dictionary.Add(Tuple.Create(DetailType.Brakes, Significance.Critical), "Замена тормозных приводов");
            dictionary.Add(Tuple.Create(DetailType.Chassis, Significance.Critical), "Замена трансмиссии");
            dictionary.Add(Tuple.Create(DetailType.Electronics, Significance.Critical), "Замена компьютера");
            dictionary.Add(Tuple.Create(DetailType.Engine, Significance.Critical), "Замена поршней");
            dictionary.Add(Tuple.Create(DetailType.Hull, Significance.Critical), "Замена частей корпуса");
            dictionary.Add(Tuple.Create(DetailType.Interior, Significance.Critical), "Замена сидений");
        }
        private void InitFatalMaintetances()
        {
            dictionary.Add(Tuple.Create(DetailType.Brakes, Significance.Fatal), "Замена тормозной системы целиком");
            dictionary.Add(Tuple.Create(DetailType.Chassis, Significance.Fatal), "Замена ходовой части целиком");
            dictionary.Add(Tuple.Create(DetailType.Electronics, Significance.Fatal), "Замена электроники целиком");
            dictionary.Add(Tuple.Create(DetailType.Engine, Significance.Fatal), "Замена двигателя целиком");
            dictionary.Add(Tuple.Create(DetailType.Hull, Significance.Fatal), "Замена корпуса целиком");
            dictionary.Add(Tuple.Create(DetailType.Interior, Significance.Fatal), "Замена обшивки целиком");
        }


        /// <summary>
        /// Возвращает название услуги.
        /// </summary>
        /// <param name="detail">Деталь для починки.</param>
        /// <param name="significance">Уровень поломки.</param>
        /// <returns>Возвращает строку.</returns>
        public string GetName(DetailType detail, Significance significance)
        {
            return dictionary[Tuple.Create(detail, significance)];
        }
    }
}