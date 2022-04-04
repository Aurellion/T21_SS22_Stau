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
            PositionX = 400 * rnd.NextDouble();
            PositionY = 400 * rnd.NextDouble();
            GeschwindigkeitX = 280 + 40 * rnd.NextDouble();
            GeschwindigkeitY = 280 + 40 * rnd.NextDouble();
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

        public void Bewegen(TimeSpan interval)
        {
            PositionX += GeschwindigkeitX * interval.TotalMinutes;
            PositionY += GeschwindigkeitY * interval.TotalMinutes;
        }

    }
}
