using Autoservice.Classes.Car.Details;
using Autoservice.Enums;

namespace Autoservice.Interfaces
{
    public interface IDetailFactory
    {
        DetailType DetailType { get; }

        Detail CreateDetail();
    }
}