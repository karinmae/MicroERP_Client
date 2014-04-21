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
    class RectangleShape
    {
        public Path Shape { get; set; }

        public RectangleShape(double posX, double posY, double width, double Height, int id, Brush brush)
        {
            Shape = new Path
            {
                Fill = brush,
                Stroke = Brushes.Black,
                Data = new RectangleGeometry(new Rect(posX, posY,width, Height)),
                Tag = id
            };
        }
    }
}
