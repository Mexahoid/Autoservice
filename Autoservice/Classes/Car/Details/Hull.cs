﻿using System;
using Autoservice.Enums;

namespace Autoservice.Classes.Car.Details
{
    public class Hull : Detail
    {
        public Hull() : base(DetailType.Hull)
        {

        }
        

        public override Detail Clone()
        {
            return new Hull
            {
                Flaw = Flaw,
                R = R,
                DetailType = DetailType
            };
        }
    }
}
