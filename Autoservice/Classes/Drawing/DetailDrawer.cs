using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Autoservice.Classes.CarClasses.Details;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Drawing
{
    class DetailDrawer : IDrawable
    {
        private readonly Detail detail;
        private static readonly object locker = new object();

        public DetailDrawer(Detail detail)
        {
            this.detail = detail;
        }

        public void AddHandler(Action handler)
        {
            detail.SomethingChanged += handler;
        }

        public void RemoveHandler(Action handler)
        {
            detail.SomethingChanged -= handler;
        }

        public void Draw(Graphics graphics)
        {
            int y;
            string detailText;
            switch (detail.DetailType)
            {
                case DetailType.Engine:
                    detailText = "Двигатель";
                    y = 60;
                    break;
                case DetailType.Chassis:
                    detailText = "Ходовая часть";
                    y = 105;
                    break;
                case DetailType.Brakes:
                    detailText = "Тормозная система";
                    y = 150;
                    break;
                case DetailType.Electronics:
                    detailText = "Электроника";
                    y = 195;
                    break;
                case DetailType.Hull:
                    detailText = "Корпус";
                    y = 240;
                    break;
                case DetailType.Interior:
                    detailText = "Салон";
                    y = 285;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Color c;

            if(detail.HasFlaw())
            switch (detail.GetFlawSignificance())
            {
                case Significance.Minor:
                    c = Color.Green;
                    break;
                case Significance.Average:
                    c = Color.Yellow;
                        break;
                case Significance.Serious:
                    c = Color.Orange;
                        break;
                case Significance.Critical:
                    c = Color.OrangeRed;
                        break;
                case Significance.Fatal:
                    c = Color.Red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            else
            {
                c = Color.DodgerBlue;
            }

            string flawText = detail.HasFlaw() ? detail.GetFlawText() : "Все в порядке";

            DrawLocked(c, graphics, new []{ detailText , flawText}, y);
        }

        private static void DrawLocked(Color c, Graphics g, string[] texts, int y)
        {
            lock (locker)
            {
                Pen p = new Pen(Color.Black);
                Brush b = new SolidBrush(c);
                g.FillRectangle(b, 330, y, 150, 45);
                b = new SolidBrush(Color.Black);
                g.DrawRectangle(p, 330, y, 150, 22);
                g.DrawString(texts[0], new Font(FontFamily.GenericMonospace, 10), b, 330, y);
                g.DrawRectangle(p, 330, y + 22, 150, 23);
                g.DrawString(texts[1], new Font(FontFamily.GenericMonospace, 10), b, 330, y + 22);
            }
        }

        public bool IsInterfere(int x, int y)
        {
            return false;
        }

        public bool IsPointerIn(int x, int y)
        {
            return false;
        }
    }
}
