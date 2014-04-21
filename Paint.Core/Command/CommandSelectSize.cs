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
    class CommandSelectSize : ICommands
    {
        double posX;
        double posY;
       
        Brush brush;
        GenericShape select;

        RectangleShape rectangle;
      

        public CommandSelectSize(double posX, double posY, GenericShape select, Brush brush)
        {
            this.posX = posX;
            this.posY = posY;
            this.select = select;
            this.brush = brush;
        }

        public void Execute()
        {
            //GenericShape newForm = shapeContainer.shapes[newShapeIndex];
            double width = Math.Abs(select.position.X - posX);
            double height = Math.Abs(select.position.Y - posY);
            rectangle = new RectangleShape(select.position.X - 5, select.position.Y - 5, width, height, 0, brush);
        }

        public Path getShape()
        {
            return rectangle.Shape;
        }
    }
}

