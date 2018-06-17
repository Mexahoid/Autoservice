using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoservice.Classes.Service;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Drawing
{
    public class MaintenanceServiceDrawer : IDrawable
    {
        private IPositionable service;
        private int my_left, my_top, width = 120, height = 160;



        public MaintenanceServiceDrawer(IPositionable service, int x, int y)
        {
            my_left = x;
            my_top = y;
            this.service = service;
        }

        public void Draw(Graphics graphics)
        {

            Brush b = new SolidBrush(Color.Black);
            graphics.DrawString(((MaintenanceService)service).Name, 
                new Font(FontFamily.GenericMonospace, 10), b, my_left - 60, my_top - 80);
            graphics.DrawImage(service.GetImage(), my_left - 60, my_top - 60, width, height - 40);
            graphics.DrawString($"Рабочих: {((MaintenanceService)service).GetWorkersCount()}",
                new Font(FontFamily.GenericMonospace, 10), b, my_left - 60, my_top + 60);
        }

        public bool IsInterfere(int x, int y)
        {
            Rectangle r = new Rectangle(x - 60, y - 80, width, height);
            Rectangle m = new Rectangle(my_left, my_top, width, height);
            return r.IntersectsWith(m);
        }

        public bool IsPointerIn(int x, int y)
        {
            return x + 60 < my_left + width &&
                   x + 60 > my_left &&
                   y + 60 > my_top &&
                   y + 60 < my_top + height;
        }
    }
}
