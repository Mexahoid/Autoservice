using System;
using System.Drawing;

namespace Autoservice.Interfaces
{
    public interface IPositionable
    {
        Bitmap GetImage();

        void AddHandler(Action signal);

        void RemoveHandler(Action signal);
    }
}