using System;
using System.Collections.Generic;
using Autoservice.Enums;

namespace Autoservice.Classes.Service
{
    /// <summary>
    /// Класс услуги починки детали.
    /// </summary>
    public class Maintenance
    {
        /// <summary>
        /// Название услуги.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Деталь, которую можно починить.
        /// </summary>
        private readonly DetailType fixableDetail;

        /// <summary>
        /// Максимальная степень поломки, которую можно починить.
        /// </summary>
        private readonly Significance fixableFlawLevel;

        /// <summary>
        /// Конструктор услуги по починке.
        /// </summary>
        /// <param name="name">Название услуги.</param>
        /// <param name="fixableDetail">Деталь для починки.</param>
        /// <param name="fixableFlawLevel">Максимальная степень поломки.</param>
        public Maintenance(string name, DetailType fixableDetail, Significance fixableFlawLevel)
        {
            Name = name;
            this.fixableDetail = fixableDetail;
            this.fixableFlawLevel = fixableFlawLevel;
        }
        
        /// <summary>
        /// Проверка возможностей услуги.
        /// </summary>
        /// <param name="detail">Тип детали.</param>
        /// <param name="significance">Степень поломки.</param>
        /// <returns>Возвращает логическое выражение.</returns>
        public bool CheckFlaw(DetailType detail, Significance? significance)
        {
            // Если детали равны и возможности выше поломки
            return fixableDetail.CompareTo(detail) == 0 &&
                   fixableFlawLevel.CompareTo(significance) >= 0;
        }
    }
}