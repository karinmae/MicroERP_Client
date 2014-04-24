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
    class CommandSelectStart : ICommands
    {
        double posX;
        double posY;
        int newShapeIndex;
        GenericShape select;

        Brush brush;

        RectangleShape rectangle;

        public CommandSelectStart(double posX, double posY, GenericShape select, Brush brush)
        {
            this.posX = posX;
            this.posY = posY;
            this.brush = brush;
            this.select = select;
        }

        public void Execute()
        {
            //GenericShape newForm = new GenericShape();
            rectangle = new RectangleShape(posX, posY, 0, 0, newShapeIndex, brush);

            select.Shape = rectangle.Shape;
            select.position = new Point(posX, posY);
            select.ShapeTyp = GenericShape.type.Rectangle;

            //shapeContainer.shapes.Add(newShapeIndex, newForm);
        }


    }
}

