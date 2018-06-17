using Autoservice.Classes.CarClasses.Details;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Factories
{
    public class InteriorFactory : IDetailFactory
    {
        public DetailType DetailType { get; }

        private readonly Interior interior;

        public InteriorFactory()
        {
            interior = new Interior();
            DetailType = DetailType.Interior;
        }


        public Detail CreateDetail()
        {
            return interior.Clone();
        }
    }
}