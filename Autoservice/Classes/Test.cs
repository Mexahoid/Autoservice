using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Classes
{
    public class Test
    {
        private readonly Manager mgr = Manager.GetInstance();

        public Test()
        {
            for (int i = 0; i < 5; i++)
            {
            }

            for (int i = 0; i < 10; i++)
            {
                mgr.MakeClient();
            }
        }


        public void Stop()
        {
            mgr.Stop();
        }
    }
}
