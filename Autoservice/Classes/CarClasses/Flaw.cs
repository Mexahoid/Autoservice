using System;
using System.Threading;
using Autoservice.Enums;

namespace Autoservice.Classes.CarClasses
{
    /// <summary>
    /// Класс для поломок.
    /// </summary>
    public class Flaw
    {
        /// <summary>
        /// Важность поломки.
        /// </summary>
        public Significance FlawLevel { get; }
        
        /// <summary>
        /// Название поломки.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Комментарий к поломке.
        /// </summary>
        public string Comment { get; }
        
        public Flaw(DetailType detail)
        {
            var r = new Random(DateTime.UtcNow.Millisecond + 1000);
            // Подождать 20 мс., чтобы рандом был настоящим.
            Thread.Sleep(20);
            // От 0 до 200 - мелкая, от 400 до 200 - обычная etc.
            int flawLevelInt = (r.Next(0, 1000) / 200 + 1) * 200;
            FlawLevel = (Significance)flawLevelInt;
            
            switch (FlawLevel)
            {
                case Significance.Minor:
                    Comment = "Почти в порядке.";
                    break;
                case Significance.Average:
                    Comment = "Средне.";
                    break;
                case Significance.Serious:
                    Comment = "Серьезно.";
                    break;
                case Significance.Critical:
                    Comment = "Очень серьезно.";
                    break;
                case Significance.Fatal:
                    Comment = "Фатально.";
                    break;
            }

            switch (detail)
            {
                case DetailType.Engine:
                    Name = "Поломка двигателя.";
                    break;
                case DetailType.Chassis:
                    Name = "Поломка ходовой части.";
                    break;
                case DetailType.Brakes:
                    Name = "Неполадки в тормозной системе.";
                    break;
                case DetailType.Electronics:
                    Name = "Короткое замыкание в электронике автомобиля.";
                    break;
                case DetailType.Hull:
                    Name = "Помятый корпус.";
                    break;
                case DetailType.Interior:
                    Name = "Испорченный салон.";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(detail), detail, null);
            }
        }
    }
}