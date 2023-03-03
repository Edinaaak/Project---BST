using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Proba
{
    public class Linija : Window
    {

        public Point startPoint { get; set; }
        public Point endPoint { get; set; }

        public Linija(double X1, double X2, double Y1, double Y2)
        {
            startPoint = new Point(X1, Y1);
            endPoint = new Point(X2, Y2);

        }

      
    }
}
