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
    class CommandMoveEllipse : ICommands
    {
        double dX;
        double dY;
        int newShapeIndex;
        CanvasShapeContainer shapeContainer;
        Path HitResult;
        Brush brush;

        EllipseShape Ellipse;

        public CommandMoveEllipse(double dX, double dY, int newShapeIndex, CanvasShapeContainer shapeContainer, Path HitResult, Brush brush)
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
            EllipseGeometry currentShape = geomerty as EllipseGeometry;

            GenericShape form = shapeContainer.shapes[newShapeIndex];

            double width = 2*currentShape.RadiusX;
            double height = 2*currentShape.RadiusY;

            Ellipse = new EllipseShape(form.position.X + dX, form.position.Y + dY, width, height, newShapeIndex, brush);
            form.Shape = Ellipse.Shape;
            form.position = new Point(form.position.X + dX, form.position.Y + dY);

            shapeContainer.UpdateShape(form, newShapeIndex);
        }
    }
}
