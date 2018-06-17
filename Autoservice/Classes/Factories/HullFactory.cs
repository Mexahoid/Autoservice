using Autoservice.Classes.CarClasses.Details;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Factories
{
    public class HullFactory : IDetailFactory
    {
        public DetailType DetailType { get; }

        private readonly Hull hull;

        public HullFactory()
        {
            hull = new Hull();
            DetailType = DetailType.Hull;
        }


        public Detail CreateDetail()
        {
            return hull.Clone();
        }
    }
}