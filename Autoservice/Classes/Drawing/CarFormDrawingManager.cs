using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Autoservice.Classes.CarClasses;
using Autoservice.Classes.CarClasses.Details;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Drawing
{
    public class CarFormDrawingManager : DrawingManager
    {
        private static CarFormDrawingManager _instance;
        

        private CarFormDrawingManager()
        {
            Drawers = new List<IDrawable>();
        }

        public static CarFormDrawingManager GetInstance()
        {
            return _instance ?? (_instance = new CarFormDrawingManager());
        }

        public void Clear()
        {
            Drawers.Clear();
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
            foreach (IDrawable t in Drawers)
            {
                if (t is DetailDrawer dd)
                {
                    dd.RemoveHandler(Draw);
                }
            }
            Drawers.Clear();

            Drawers.Add(new CarDrawer(entity));
            Car c = (Car) entity;
            foreach (Detail detail in c.GetBrokenDetails(true))
            {
                detail.SomethingChanged += Draw;
                Drawers.Add(new DetailDrawer(detail));
            }
        }

        public Action GetDrawAction()
        {
            return Draw;
        }
    }
}