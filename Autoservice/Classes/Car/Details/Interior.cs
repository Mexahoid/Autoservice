using System;
using Autoservice.Enums;

namespace Autoservice.Classes.Car.Details
{
    public class Interior : Detail
    {
        public Interior() : base(DetailType.Interior)
        {

        }
        

        public override Detail Clone()
        {
            return new Interior
            {
                Flaw = Flaw,
                R = R,
                DetailType = DetailType
            };
        }
    }
}