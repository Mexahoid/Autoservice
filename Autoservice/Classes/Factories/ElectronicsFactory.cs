using Autoservice.Classes.Car.Details;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Factories
{
    public class ElectronicsFactory : IDetailFactory
    {
        public DetailType DetailType { get; }

        private readonly Electronics electronics;

        public ElectronicsFactory()
        {
            electronics = new Electronics();
            DetailType = DetailType.Electronics;
        }


        public Detail CreateDetail()
        {
            return electronics.Clone();
        }
    }
}