using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Stau
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Auto[] autos = new Auto[3];

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(17);
            timer.Start();
            timer.Tick += animiere;

            for (int i = 0; i < 3; i++)
            {
                autos[i] = new Auto(Zeichenfläche);
            }
        }

        private void animiere(object sender, EventArgs e)
        {
            Zeichenfläche.Children.Clear();
            foreach (Auto item in autos)
            {
                item.Bewegen(timer.Interval);
                item.Zeichnen(Zeichenfläche);
            }
        }
    }
}
