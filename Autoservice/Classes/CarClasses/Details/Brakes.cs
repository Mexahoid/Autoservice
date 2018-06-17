using System;
using Autoservice.Enums;

namespace Autoservice.Classes.CarClasses.Details
{
    public class Brakes : Detail
    {
        public Brakes() : base(DetailType.Brakes)
        {
        }

        public override Detail Clone()
        {
            return new Brakes
            {
                Flaw = Flaw,
                DetailType = DetailType
            };
        }
    }
}