namespace Autoservice.Enums
{
    /// <summary>
    /// Перечисление для важности поломки.
    /// </summary>
    public enum Significance
    {
        /// <summary>
        /// Незначительная поломка.
        /// </summary>
        Minor = 200,
        /// <summary>
        /// Обычная поломка.
        /// </summary>
        Average = 400,
        /// <summary>
        /// Серьезная поломка.
        /// </summary>
        Serious = 600,
        /// <summary>
        /// Критичная поломка.
        /// </summary>
        Critical = 800,
        /// <summary>
        /// Терминальная поломка.
        /// </summary>
        Fatal = 1000
    }
}