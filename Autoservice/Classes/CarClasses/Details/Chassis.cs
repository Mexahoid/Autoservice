using System;
using Autoservice.Enums;

namespace Autoservice.Classes.CarClasses.Details
{
    public class Chassis : Detail
    {
        public Chassis() : base(DetailType.Chassis)
        {

        }

        public override Detail Clone()
        {
            return new Chassis
            {
                Flaw = Flaw,
                R = R,
                DetailType = DetailType
            };
        }
    }
}