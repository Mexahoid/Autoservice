using System;
using Autoservice.Enums;

namespace Autoservice.Classes.Car.Details
{
    public class Engine : Detail
    {
        public Engine() : base(DetailType.Engine)
        {

        }

        public override Detail Clone()
        {
            return new Engine
            {
                Flaw = Flaw,
                R = R,
                DetailType = DetailType
            };
        }
    }
}