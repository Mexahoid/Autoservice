using Autoservice.Classes.CarClasses.Details;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Factories
{
    public class BrakesFactory : IDetailFactory
    {
        public DetailType DetailType { get; }

        private readonly Brakes brakes;

        public BrakesFactory()
        {
            brakes = new Brakes();
            DetailType = DetailType.Brakes;
        }


        public Detail CreateDetail()
        {
            return brakes.Clone();
        }
    }
}