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

namespace Paint.Core.Models
{
    class EllipseShape
    {
        public Path Shape { get; set; }

        public EllipseShape(double posX, double posY, double radiusX, double radiusY, int id)
        {
            Shape = new Path
            {
                
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Data = new EllipseGeometry(new Rect(posX, posY, radiusX, radiusY)),
                Tag = id
            };
        }

    }
}
