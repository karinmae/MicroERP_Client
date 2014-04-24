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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Paint.Core.Models;
using Paint.Core.ViewModels;
using Paint.Core.Command;

namespace Paint.Core.Helper
{
    class RectangleHelper
    {
        Path path;
        Point topLeft;

        public RectangleHelper(Path path)
        {
            Geometry geomerty = path.Data;
            RectangleGeometry currentShape = geomerty as RectangleGeometry;
            topLeft = currentShape.Rect.TopLeft;
        }

        public Point getTopLeft()
        {
            return topLeft;
        }

    }
}
