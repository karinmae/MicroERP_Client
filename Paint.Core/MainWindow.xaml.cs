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
using Paint.Core.Composite;


namespace Paint.Core
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        
        MatrixTransform transform;
        Point StartPoint;
        RectangleShape rectangle;
        EllipseShape ellipse;
        Path tempForm;

        ShapeComposite group1;
   
        bool IsResizeMode;
        bool IsDragAndDropMode;
        bool newShape_regtangle;
        bool newShape_ellipse;
        //bool newShape;
        bool group;
       
        double distanzX;
        double distanzY;

        int newShapeIndex;

        private MVVMViewModel dataContainer = new MVVMViewModel();
        
        CanvasShapeContainer shapeContainer;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = dataContainer;

            shapeContainer = new CanvasShapeContainer();
            transform = new MatrixTransform();
            
            tempForm = new Path();

            IsResizeMode = false;
            IsDragAndDropMode = true;
            group = false;

            newShapeIndex = 0;

            group1 = new ShapeComposite();
        }

        #region Add Shapes and define the mode
        

        private void MenuItem_ResizeMode(object sender, RoutedEventArgs args)
        {
            IsResizeMode = true;
            IsDragAndDropMode = false;
            newShape_ellipse = false;
            newShape_regtangle = false;
        }

        private void MenuItem_DragAndDropMode(object sender, RoutedEventArgs args)
        {
            IsDragAndDropMode = true;
            IsResizeMode = false;
            newShape_regtangle = false;
            newShape_ellipse = false;
        }

        private void MenuItem_Rectangle(object sender, RoutedEventArgs e)
        {
            newShape_regtangle = true;
            IsDragAndDropMode = false;
            IsResizeMode = false;
            newShape_ellipse = false;

        }

        private void MenuItem_Ellipse(object sender, RoutedEventArgs e)
        {
            newShape_ellipse = true;
            IsDragAndDropMode = false;
            IsResizeMode = false;
            newShape_regtangle = false;
        }

        private void MenuItem_Group(object sender, RoutedEventArgs e)
        {
            group = true;
            IsDragAndDropMode = false;
            IsResizeMode = false;
            newShape_ellipse = false;
            newShape_regtangle = false;
        }

        #endregion

        private void Scene_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HitTestResult result = VisualTreeHelper.HitTest(Scene, Mouse.GetPosition(Scene));
            Path path = result.VisualHit as Path;

            StartPoint = e.GetPosition(Scene);

            double posX = e.GetPosition(Scene).X;
            double posY = e.GetPosition(Scene).Y;

            if (newShape_regtangle == true)
            {
                ICreateCommand com = new CommandCreateRect(posX, posY, newShapeIndex, shapeContainer);
                com.Execute();
            }
            else if (newShape_ellipse == true)
            {
                ICreateCommand comd = new CommandCreateEllipse(posX, posY, newShapeIndex, shapeContainer);
                comd.Execute();
            }
            else if (group == true)
            {
                int index = Convert.ToInt32(path.Tag.ToString());
                GenericShape form1 = shapeContainer.shapes[index];
                group1.add(form1);
            }
            else
            {
                if (path != null)
                {
                    path.Fill = Brushes.CadetBlue;

                    RectangleHelper rh = new RectangleHelper(path);
                    Point topLeft = rh.getTopLeft();

                    distanzX = StartPoint.X - topLeft.X;
                    distanzY = StartPoint.Y - topLeft.Y;

                }
            }
        }

        private void Scene_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            double posX = e.GetPosition(Scene).X;
            double posY = e.GetPosition(Scene).Y;

            if (newShape_regtangle == true)
            {
                if (shapeContainer.shapes.ContainsKey(newShapeIndex))
                {
                    IFinalizeCommand com = new CommandFinalizeRect(posX, posY, newShapeIndex, shapeContainer);
                    com.Execute();

                    newShapeIndex++;
                    Render();     
                }
            }
            else if (newShape_ellipse == true)
            {
                if(shapeContainer.shapes.ContainsKey(newShapeIndex))
                {
                    IFinalizeCommand comd = new CommandFinalizeEllipse(posX, posY, newShapeIndex, shapeContainer);
                    comd.Execute();

                    newShapeIndex++;
                    Render();
                }
            }
            else
            {
                HitTestResult result = VisualTreeHelper.HitTest(Scene, Mouse.GetPosition(Scene));
                Path path = result.VisualHit as Path;
               

                if (IsDragAndDropMode == true && IsResizeMode == false)
                {
                    if (path.Data.GetType() == typeof(RectangleGeometry))
                    {
                        int index = Convert.ToInt32(path.Tag.ToString());

                        Geometry geomerty = path.Data;
                        RectangleGeometry currentShape = geomerty as RectangleGeometry;
                        Point topLeft = currentShape.Rect.TopLeft;

                        GenericShape form = shapeContainer.shapes[index];
                        
                        double width = currentShape.Rect.Width;
                        double height = currentShape.Rect.Height;

                        rectangle = new RectangleShape(posX - distanzX, posY - distanzY, width, height, index);
                        form.Shape = rectangle.Shape;
                        form.position = new Point(posX, posY);

                        shapeContainer.UpdateShape(form, index);

                        Render();
                    }

                    //if (path.Data.GetType() == typeof(EllipseGeometry))
                    //{
                    //    int index = Convert.ToInt32(path.Tag.ToString());

                    //    Geometry geomerty = path.Data;
                    //    EllipseGeometry currentShape = geomerty as EllipseGeometry;
                    //    Point center = currentShape.Center;

                    //    GenericShape form = shapeContainer.shapes[index];

                    //    double width = currentShape.Rect.Width;
                    //    double height = currentShape.Rect.Height;

                    //    rectangle = new RectangleShape(posX - distanzX, posY - distanzY, width, height, index);
                    //    form.Shape = rectangle.Shape;
                    //    form.position = new Point(posX, posY);

                    //    shapeContainer.UpdateShape(form, index);

                    //    Render();
                    //}
                }
            }
        }

        private void Scene_MouseMove(object sender, MouseEventArgs e)
        {
            double posX = e.GetPosition(Scene).X;
            double posY = e.GetPosition(Scene).Y;

            if (newShape_regtangle == true) {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    if (shapeContainer.shapes.ContainsKey(newShapeIndex))
                    {
                        if (Scene.Children.Contains(tempForm))
                            Scene.Children.Remove(tempForm);
                       
                        ISetSizeCommand com = new CommandSetSizeRect(posX, posY, newShapeIndex, shapeContainer);
                        com.Execute();
                        tempForm = com.getShape();
                        Scene.Children.Add(tempForm);
                    }
                }
            }
            else if (newShape_ellipse == true)
            {
                if (shapeContainer.shapes.ContainsKey(newShapeIndex))
                {
                    if (Scene.Children.Contains(tempForm))
                        Scene.Children.Remove(tempForm);

                    ISetSizeCommand comd = new CommandSetSizeEllipse(posX, posY, newShapeIndex, shapeContainer);
                    comd.Execute();
                    tempForm = comd.getShape();
                    Scene.Children.Add(tempForm);
                }
            }
            else
            {
              
                HitTestResult result = VisualTreeHelper.HitTest(Scene, Mouse.GetPosition(Scene));
                Path path = result.VisualHit as Path;


                if (IsDragAndDropMode == true && IsResizeMode == false)
                {
                    if (Mouse.LeftButton == MouseButtonState.Pressed)
                    {
                        if (path != null)
                        {
                            transform.Matrix = new Matrix(1, 0, 0, 1,
                                 posX - StartPoint.X,
                                 posY - StartPoint.Y);
                            path.RenderTransform = transform;
                        }
                    }
                }
            }
        }

        private void Render()
        {
            Scene.Children.Clear();
            foreach (var pair in shapeContainer.shapes)
            {
                GenericShape temp = pair.Value;
                Scene.Children.Add(temp.Shape);
            }
        }

       
    }

   


}
