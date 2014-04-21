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
    class CanvasShapeContainer
    {
        public Dictionary<int, GenericShape> shapes { get; set; }

        public CanvasShapeContainer()
        {
            shapes = new Dictionary<int, GenericShape>();
        }

        public void UpdateShape(GenericShape shape, int index){
            shapes[index] = shape;
        }
    }
}
