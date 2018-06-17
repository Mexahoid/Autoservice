using System;
using System.Drawing;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Drawing
{
    public class CarDrawer : IDrawable
    {
        private readonly IPositionable cdw;


        public CarDrawer(IPositionable cdw)
        {
            this.cdw = cdw;
        }

        public void Draw(Graphics graphics)
        {
            const int x = 60;
            const int y = 60;
            const int width = 270;
            const int height = 270;
            graphics.DrawImage(cdw.GetImage(), x, y, width, height);
        }

        public bool IsInterfere(int x, int y)
        {
            throw new Exception("Данный метод вызывать для данного класса нельзя.");
        }

        public bool IsPointerIn(int x, int y)
        {
            throw new Exception("Данный метод вызывать для данного класса нельзя.");
        }
    }
}