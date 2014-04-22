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
    class Marker
    {
        public Path Shape { get; set; }

        public Marker(Point start, Point end, int id, Brush brush)
        {
            Shape = new Path
            {

                Stroke = brush,
                StrokeThickness = 15,
                Data = new LineGeometry(start, end),
                Tag = id
            };
        }
    }
}
