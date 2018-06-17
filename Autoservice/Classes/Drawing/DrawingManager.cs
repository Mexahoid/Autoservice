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
        protected PaintEventArgs tempCanv;

        /// <summary>
        /// Канва, связанная с изображением.
        /// </summary>
        protected Graphics canvasDrawing;

        /// <summary>
        /// Изображение, которым оперируют рисовальщики.
        /// </summary>
        protected Bitmap bitmap;

        protected IList<IDrawable> drawers;

        /// <summary>
        /// Задает канву рисования.
        /// </summary>
        /// <param name="control">Элемент управления, на котором осуществляется рисование.</param>
        public void SetCanvas(Control control)
        {
            bitmap = new Bitmap(control.Width, control.Height);
            canvasDrawing = Graphics.FromImage(bitmap);
            tempCanv = new PaintEventArgs(control.CreateGraphics(), control.ClientRectangle);
        }

        public void Draw()
        {
            canvasDrawing.Clear(Color.White);
            foreach (IDrawable drawable in drawers)
            {
                drawable.Draw(canvasDrawing);
            }
            tempCanv.Graphics.DrawImage(bitmap, 0, 0);
        }

        public abstract Bitmap GetImage();

        public abstract void AddDrawable(IPositionable drawer, int x, int y);
    }
}
