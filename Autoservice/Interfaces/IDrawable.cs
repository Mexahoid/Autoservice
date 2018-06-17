using System.Drawing;

namespace Autoservice.Interfaces
{
    public interface IDrawable
    {
        /// <summary>
        /// Метод отрисовки.
        /// </summary>
        /// <param name="graphics">Канва, на которой производится отрисовка.</param>
        void Draw(Graphics graphics);


        bool IsInterfere(int x, int y);

        bool IsPointerIn(int x, int y);
    }
}