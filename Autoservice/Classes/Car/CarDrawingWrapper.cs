using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Classes.Car
{
    public class CarDrawingWrapper
    {
        private event Action GetCarPos;


        public CarDrawingWrapper(Action carPosGetter)
        {
            GetCarPos += carPosGetter;
        }


        protected virtual void OnGetCarPos()
        {
            GetCarPos?.Invoke();
        }
    }
}
