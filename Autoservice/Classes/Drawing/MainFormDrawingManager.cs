using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Drawing
{
    public class MainFormDrawingManager : DrawingManager
    {
        private static MainFormDrawingManager _instance;
        
        private MainFormDrawingManager()
        {
            drawers = new List<IDrawable>();
        }

        public static MainFormDrawingManager GetInstance()
        {
            return _instance ?? (_instance = new MainFormDrawingManager());
        }


        public override Bitmap GetImage()
        {
            lock (new object())
            {
                return Resources.service;
            }
        }

        public override void AddDrawable(IPositionable drawer, int x, int y)
        {
            if (drawer == null)
                return;
            IDrawable drw = new MaintenanceServiceDrawer(drawer, x, y);
            drawers.Add(drw);
        }

        public bool TryAddService(int x, int y)
        {
            //if(x - 60 < 30 || y - 60 < 30 || x + 60 > 380 || y + 60 > 270)
                //return false;
            return !drawers.Any(drawable => drawable.IsInterfere(x, y));
        }

        public int FindMaintenanceByPointer(int x, int y)
        {
            for (int i = 0; i < drawers.Count; i++)
            {
                if (drawers[i].IsPointerIn(x, y))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
