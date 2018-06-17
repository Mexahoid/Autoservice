using System;
using Autoservice.Enums;

namespace Autoservice.Classes.CarClasses.Details
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
                DetailType = DetailType
            };
        }
    }
}