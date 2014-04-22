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
    class CommandCreateMarker : ICommands
    {
        Point start;
        Point end;
        int newShapeIndex;
        CanvasShapeContainer shapeContainer;

        Brush brush;

        Marker marker;

        public CommandCreateMarker(Point start, Point end, int newShapeIndex, CanvasShapeContainer shapeContainer, Brush brush)
        {
            this.start = start;
            this.end = end;
            this.newShapeIndex = newShapeIndex;
            this.shapeContainer = shapeContainer;
            this.brush = brush;
        }

        public void Execute()
        {
            GenericShape newForm = new GenericShape();

            marker = new Marker(start, end, newShapeIndex, brush);

            newForm.Shape = marker.Shape;
            //newForm.position = new Point(start, end);
            newForm.ShapeTyp = GenericShape.type.Marker;

            shapeContainer.shapes.Add(newShapeIndex, newForm);

        }
    }
}
