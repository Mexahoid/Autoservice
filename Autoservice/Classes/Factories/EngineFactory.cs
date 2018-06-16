using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoservice.Classes.Car.Details;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Factories
{
    public class EngineFactory : IDetailFactory
    {
        public DetailType DetailType { get; }

        private readonly Engine engine;

        public EngineFactory()
        {
            engine = new Engine();
            DetailType = DetailType.Engine;
        }

        public Detail CreateDetail()
        {
            return engine.Clone();
        }
    }
}
