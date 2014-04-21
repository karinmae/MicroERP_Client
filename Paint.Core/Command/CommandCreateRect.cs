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
    class CommandCreateRect : ICreateCommand
    {
        double posX;
        double posY;
        int newShapeIndex;
        CanvasShapeContainer shapeContainer;
       
        RectangleShape rectangle;

        public CommandCreateRect(double posX, double posY, int newShapeIndex, CanvasShapeContainer shapeContainer){
            this.posX = posX;
            this.posY = posY;
            this.newShapeIndex = newShapeIndex;
            this.shapeContainer = shapeContainer;
        }

        public void Execute(){
            GenericShape newForm = new GenericShape();
            rectangle = new RectangleShape(posX, posY, 0, 0, newShapeIndex);

            newForm.Shape = rectangle.Shape;
            newForm.position = new Point(posX, posY);
            newForm.ShapeTyp = GenericShape.type.Rectangle;

            shapeContainer.shapes.Add(newShapeIndex, newForm);
        }

        
    }
}

                