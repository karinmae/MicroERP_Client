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
    class CommandFinalizeRect : IFinalizeCommand
    {
        double posX;
        double posY;
        int newShapeIndex;
        CanvasShapeContainer shapeContainer;
        

        RectangleShape rectangle;

        public CommandFinalizeRect(double posX, double posY, int newShapeIndex, CanvasShapeContainer shapeContainer){
            this.posX = posX;
            this.posY = posY;
            this.newShapeIndex = newShapeIndex;
            this.shapeContainer = shapeContainer;
        }

        public void Execute()
        {
            GenericShape newForm = shapeContainer.shapes[newShapeIndex];

            double width = Math.Abs(newForm.position.X - posX);
            double height = Math.Abs(newForm.position.Y - posY);

            rectangle = new RectangleShape(newForm.position.X - 5, newForm.position.Y - 5, width, height, newShapeIndex);
            newForm.Shape = rectangle.Shape;
            shapeContainer.UpdateShape(newForm, newShapeIndex);
        }

    }
}
