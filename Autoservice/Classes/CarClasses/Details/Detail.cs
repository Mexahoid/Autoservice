using System;
using System.Text;
using System.Threading;
using Autoservice.Enums;

namespace Autoservice.Classes.CarClasses.Details
{
    /// <summary>
    /// Абстрактный класс для запчасти автомобиля, нельзя создать экземпляр.
    /// </summary>
    public abstract class Detail
    {
        protected static Random R = new Random(DateTime.UtcNow.Millisecond + 2000);
        private static readonly object locker = new object();

        public event Action SomethingChanged;

        /// <summary>
        /// Поломка детали.
        /// </summary>
        protected Flaw Flaw;

        /// <summary>
        /// Тип детали.
        /// </summary>
        public DetailType DetailType { get; protected set; }

        /// <summary>
        /// Конструктор предка Detail.
        /// </summary>
        /// <param name="type">Тип детали</param>
        protected Detail(DetailType type)
        {
            DetailType = type;
        }

        /// <summary>
        /// Позволяет узнать, есть ли поломка у этой детали.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool HasFlaw()
        {
            lock(locker)
                return Flaw != null;
        }

        public string GetFlawText()
        {
            return Flaw.Comment;
        }

        /// <summary>
        /// Установить поломку для детали.
        /// </summary>
        public bool TrySetRandomFlaw()
        {
            if (Flaw != null)
                return false;
            // Подождать 20 мс., чтобы рандом был настоящим.
            Thread.Sleep(20);
            if (R.Next(0, 1000) < Convert.ToInt32(DetailType))
            {
                Flaw = new Flaw(DetailType);
            }
            if (Flaw != null)
                SomethingChanged?.Invoke();
            return true;
        }

        /// <summary>
        /// Возвращает степень поломки.
        /// </summary>
        /// <returns>Возвращает Significance.</returns>
        public Significance? GetFlawSignificance()
        {
            return Flaw?.FlawLevel;
        }

        /// <summary>
        /// Чинит поломку и тратит время.
        /// </summary>
        public void FixFlaw()
        {
            lock (locker)
            {
                Thread.Sleep((int) Flaw.FlawLevel / 40 * (int) DetailType);
                Flaw = null;
            }
        }


        // Вроде для паттерна прототипа
        /// <summary>
        /// Клонирует деталь.
        /// </summary>
        /// <returns>Возвращает экземпляр Detail.</returns>
        public abstract Detail Clone();
    }
}