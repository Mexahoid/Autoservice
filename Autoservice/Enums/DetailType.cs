namespace Autoservice.Enums
{
    /// <summary>
    /// Перечисление для деталей.
    /// </summary>
    public enum DetailType
    {
        /// <summary>
        /// Двигатель, 30% шанс поломки (в 300 случаях из 1000).
        /// </summary>
        Engine = 300,
        /// <summary>
        /// Ходовая часть, 3% шанс поломки (в 30 случаях из 1000).
        /// </summary>
        Chassis = 30,
        /// <summary>
        /// Тормозная система, 5% шанс поломки (в 50 случаях из 1000).
        /// </summary>
        Brakes = 50,
        /// <summary>
        /// Электроника, 7% шанс поломки (в 70 случаях из 1000).
        /// </summary>
        Electronics = 70,
        /// <summary>
        /// Корпус, 25% шанс поломки (в 250 случаях из 1000).
        /// </summary>
        Hull = 250,
        /// <summary>
        /// Салон автомобиля, 4% шанс поломки (в 40 случаях из 1000).
        /// </summary>
        Interior = 40
            
    }

}