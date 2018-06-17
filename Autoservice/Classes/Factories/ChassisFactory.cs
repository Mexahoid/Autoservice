using Autoservice.Classes.CarClasses.Details;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Factories
{
    public class ChassisFactory : IDetailFactory
    {
        public DetailType DetailType { get; set; }

        private readonly Chassis chassis;

        public ChassisFactory()
        {
            chassis = new Chassis();
            DetailType = DetailType.Chassis;
        }

        public Detail CreateDetail()
        {
            return chassis.Clone();
        }

    }
}