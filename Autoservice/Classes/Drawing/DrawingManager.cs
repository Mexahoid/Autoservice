using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Drawing
{
    public abstract class DrawingManager
    {
        public event Action<PaintEventArgs> EventReDraw;

        /// <summary>
        /// Главный экземпляр графики.
        /// </summary>
        protected PaintEventArgs TempCanv;

        /// <summary>
        /// Канва, связанная с изображением.
        /// </summary>
        protected Graphics CanvasDrawing;

        /// <summary>
        /// Изображение, которым оперируют рисовальщики.
        /// </summary>
        protected Bitmap Bitmap;

        protected IList<IDrawable> Drawers;

        /// <summary>
        /// Задает канву рисования.
        /// </summary>
        /// <param name="control">Элемент управления, на котором осуществляется рисование.</param>
        public void SetCanvas(Control control)
        {
            Bitmap = new Bitmap(control.Width, control.Height);
            CanvasDrawing = Graphics.FromImage(Bitmap);
            TempCanv = new PaintEventArgs(control.CreateGraphics(), control.ClientRectangle);
        }

        public void Draw()
        {
            CanvasDrawing.Clear(Color.White);
            foreach (IDrawable drawable in Drawers)
            {
                drawable.Draw(CanvasDrawing);
            }
            TempCanv.Graphics.DrawImage(Bitmap, 0, 0);
        }

        public abstract Bitmap GetImage();

        public abstract void AddDrawable(IPositionable drawer, int x, int y);
    }
}
