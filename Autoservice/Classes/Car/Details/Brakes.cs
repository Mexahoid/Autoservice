﻿using System;
using Autoservice.Enums;

namespace Autoservice.Classes.Car.Details
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
                R = R,
                DetailType = DetailType
            };
        }
    }
}