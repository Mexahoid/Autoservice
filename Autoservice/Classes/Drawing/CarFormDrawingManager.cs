using System;
using System.Drawing;
using System.Windows.Forms;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Drawing
{
    public class CarFormDrawingManager : DrawingManager
    {
        private static CarFormDrawingManager _instance;

        private CarFormDrawingManager()
        {
            
        }

        public static CarFormDrawingManager GetInstance()
        {
            return _instance ?? (_instance = new CarFormDrawingManager());
        }

        public void Clear()
        {
            drawers.Clear();
        }

        public override Bitmap GetImage()
        {
            lock (new object())
            {
                return Resources.car;
            }
        }

        public override void AddDrawable(IPositionable entity, int x, int y)
        {
            drawers.Add(new CarDrawer(entity));
        }

        public Action GetDrawAction()
        {
            return Draw;
        }
    }
}