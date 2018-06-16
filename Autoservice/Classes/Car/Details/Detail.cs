﻿using System;
using System.Text;
using System.Threading;
using Autoservice.Enums;

namespace Autoservice.Classes.Car.Details
{
    /// <summary>
    /// Абстрактный класс для запчасти автомобиля, нельзя создать экземпляр.
    /// </summary>
    public abstract class Detail
    {
        protected Random R;

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
        /// <param name="type"></param>
        protected Detail(DetailType type)
        {
            DetailType = type;
            R = new Random(DateTime.UtcNow.Millisecond + (int)DetailType);
        }

        /// <summary>
        /// Позволяет узнать, есть ли поломка у этой детали.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool HasFlaw()
        {
            return Flaw != null;
        }

        /// <summary>
        /// Установить поломку для детали.
        /// </summary>
        public void TrySetRandomFlaw()
        {
            if (Flaw == null)
                return;
            // Подождать 20 мс., чтобы рандом был настоящим.
            Thread.Sleep(20);
            if (R.Next(0, 1000) < Convert.ToInt32(DetailType))
            {
                Flaw = new Flaw(DetailType);
            }
        }

        /// <summary>
        /// Возвращает степень поломки.
        /// </summary>
        /// <returns>Возвращает Significance.</returns>
        public Significance GetFlawSignificance()
        {
            if(Flaw == null)
                throw new Exception("Flaw пустое, внезапная проблема.");
            return Flaw.FlawLevel;
        }

        /// <summary>
        /// Чинит поломку и тратит время.
        /// </summary>
        public void FixFlaw()
        {
            Thread.Sleep((int)Flaw.FlawLevel / 40 * (int)DetailType);
            Flaw = null;
        }


        // Вроде для паттерна прототипа
        /// <summary>
        /// Клонирует деталь.
        /// </summary>
        /// <returns>Возвращает экземпляр Detail.</returns>
        public abstract Detail Clone();
    }
}