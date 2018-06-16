using System;
using Autoservice.Enums;

namespace Autoservice.Classes.Car.Details
{
    public class Electronics : Detail
    {
        public Electronics() : base(DetailType.Electronics)
        {

        }

        public override Detail Clone()
        {
            return new Electronics
            {
                Flaw = Flaw,
                R = R,
                DetailType = DetailType
            };
        }
    }
}