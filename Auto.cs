using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Stau
{
    class Auto
    {
        //Eigenschaften
        public double PositionX { get; private set; }
        public double PositionY { get; private set; }
        public double GeschwindigkeitX { get; private set; }
        public double GeschwindigkeitY { get; private set; }

        private static Random rnd = new Random();

        //Konstruktor
        public Auto(Canvas Zeichenfläche)
        {
            PositionX = rnd.Next(0, Convert.ToInt32( Zeichenfläche.Width) );
            PositionY = rnd.Next(0, Convert.ToInt32( Zeichenfläche.Height) );
            GeschwindigkeitX = (400 * rnd.NextDouble() + 800) * rnd.Next(-1,2);
            GeschwindigkeitY = (400 * rnd.NextDouble() + 800) * rnd.Next(-1, 2);
        }

        //Methoden
        public void Zeichnen(Canvas Zeichenfläche)
        {
            Ellipse e = new Ellipse();
            e.Width = 10;
            e.Height = 10;
            e.Fill = Brushes.Aqua;
            Canvas.SetLeft(e, PositionX);
            Canvas.SetTop(e, PositionY);
            Zeichenfläche.Children.Add(e);
        }

        public void Bewegen(TimeSpan interval, Canvas Zeichenfläche)
        {
            PositionX += GeschwindigkeitX * interval.TotalMinutes;
            PositionY += GeschwindigkeitY * interval.TotalMinutes;

            if (PositionX > Zeichenfläche.ActualWidth) PositionX = 0;
            if (PositionY > Zeichenfläche.ActualHeight) PositionY = 0;
            if (PositionX < 0) PositionX = Zeichenfläche.ActualWidth;
            if (PositionY < 0) PositionY = Zeichenfläche.ActualHeight;
        }

        public void beschleunigen(double beschleunigung)
        {
            GeschwindigkeitX += beschleunigung;
            GeschwindigkeitY += beschleunigung;
        }

    }
}
