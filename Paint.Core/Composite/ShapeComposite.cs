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
using Paint.Core.Helper;

namespace Paint.Core.Composite
{
    class ShapeComposite : GenericShape
    {
        public List<GenericShape> children {get; set;}

        public ShapeComposite()
        {
            children = new List<GenericShape>();
        }

        public void add(GenericShape component)
        {
            children.Add(component);
        }

        public void remove(GenericShape component)
        {
            children.Remove(component);
        }

    }
}
