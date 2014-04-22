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

namespace Paint.Core.Command
{
    class CommandResizeRect : ICommands
    {
        double dX;
        double dY;
        int newShapeIndex;
        CanvasShapeContainer shapeContainer;
        Path HitResult;
        Brush brush;

        RectangleShape rectangle;

        public CommandResizeRect(double dX, double dY, int newShapeIndex, CanvasShapeContainer shapeContainer, Path HitResult, Brush brush)
        {
            this.dX = dX;
            this.dY = dY;
            this.newShapeIndex = newShapeIndex;
            this.shapeContainer = shapeContainer;
            this.HitResult = HitResult;
            this.brush = brush;
        }

        public void Execute()
        {
            Geometry geomerty = HitResult.Data;
            RectangleGeometry currentShape = geomerty as RectangleGeometry;

            GenericShape form = shapeContainer.shapes[newShapeIndex];

            double width = currentShape.Rect.Width;
            double height = currentShape.Rect.Height;

            rectangle = new RectangleShape(form.position.X, form.position.Y, width + dX, height + dX, newShapeIndex, brush);
            form.Shape = rectangle.Shape;
            form.position = new Point(form.position.X, form.position.Y);

            shapeContainer.UpdateShape(form, newShapeIndex);
        }
    }
}
