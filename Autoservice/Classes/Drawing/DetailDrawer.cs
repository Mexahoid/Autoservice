using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoservice.Classes.Car.Details;
using Autoservice.Enums;
using Autoservice.Interfaces;

namespace Autoservice.Classes.Drawing
{
    class DetailDrawer : IDrawable
    {
        private readonly Detail detail;

        public DetailDrawer(Detail detail)
        {
            this.detail = detail;
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

            Pen p = new Pen(Color.Black);
            Brush b = new SolidBrush(c);

            graphics.FillRectangle(b, 330, y, 110, 45);
            b = new SolidBrush(Color.Black);
            graphics.DrawRectangle(p, 330, y, 110, 22);
            graphics.DrawString(detailText, new Font(FontFamily.GenericMonospace, 10), b, 330, y);
            graphics.DrawRectangle(p, 330, y + 22, 110, 23);
            graphics.DrawString(flawText, new Font(FontFamily.GenericMonospace, 10), b, 330, y + 22);


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
