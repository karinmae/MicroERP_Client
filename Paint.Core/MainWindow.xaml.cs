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
<<<<<<< HEAD
        
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
        
=======

        MatrixTransform transform;
        RectangleShape rectangle;
        Path tempForm;

        

        ShapeComposite composite;
        Options option = new Options();

        int newShapeIndex;

        Point StartMovePoint;
        Point EndMovePoint;

        GenericShape select = new GenericShape();

        private MVVMViewModel dataContainer = new MVVMViewModel();

>>>>>>> f4eb00236e3d87d13397a5af887720ba989a9f50
        CanvasShapeContainer shapeContainer;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = dataContainer;

            shapeContainer = new CanvasShapeContainer();
            transform = new MatrixTransform();
<<<<<<< HEAD
            
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
=======

            tempForm = new Path();
            newShapeIndex = 0;

           
            composite = new ShapeComposite();
        }

        #region Add Shapes and define the mode


        private void MenuItem_ResizeMode(object sender, RoutedEventArgs args)
        {

        }

        private void MenuItem_DragAndDropMode(object sender, RoutedEventArgs args)
        {
            option.type = Options.op.moveShape;
        }
        private void MenuItem_Shape(object sender, RoutedEventArgs e)
        {
            option.type = Options.op.newShape;
>>>>>>> f4eb00236e3d87d13397a5af887720ba989a9f50
        }

        private void MenuItem_Group(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            group = true;
            IsDragAndDropMode = false;
            IsResizeMode = false;
            newShape_ellipse = false;
            newShape_regtangle = false;
        }

=======
            option.type = Options.op.groupShape;
        }


>>>>>>> f4eb00236e3d87d13397a5af887720ba989a9f50
        #endregion

        private void Scene_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
<<<<<<< HEAD
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
=======
            ICommands com;
            x.Text = " down";
            HitTestResult result = VisualTreeHelper.HitTest(Scene, Mouse.GetPosition(Scene));
            Path path = result.VisualHit as Path;

            StartMovePoint = e.GetPosition(Scene);
            double posX = e.GetPosition(Scene).X;
            double posY = e.GetPosition(Scene).Y;

            switch (option.type)
            {
                case Options.op.newShape:
                    com = new CommandCreateRect(posX, posY, newShapeIndex, shapeContainer, Brushes.Blue);
                    com.Execute();
                    break;

                case Options.op.moveShape:
                    if (path != null)
                    {
                        path.Fill = Brushes.CadetBlue;
                    }
                    break;

                case Options.op.groupShape:
                    ShapeComposite group = new ShapeComposite();
                    com = new CommandSelectStart(posX, posY, select, Brushes.Transparent);
                    com.Execute();

                    //int index = Convert.ToInt32(path.Tag.ToString());
                    //GenericShape form1 = shapeContainer.shapes[index];
                    //group1.add(form1);
                    break;
            }

>>>>>>> f4eb00236e3d87d13397a5af887720ba989a9f50
        }

        private void Scene_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
<<<<<<< HEAD
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
=======
            x.Text = " UP";
            EndMovePoint = e.GetPosition(Scene);
            double dX = EndMovePoint.X - StartMovePoint.X;
            double dY = EndMovePoint.Y - StartMovePoint.Y;

            switch (option.type)
            {
                case Options.op.newShape:
                    if (shapeContainer.shapes.ContainsKey(newShapeIndex))
                    {
                        ICommands com = new CommandFinalizeRect(EndMovePoint.X, EndMovePoint.Y, newShapeIndex, shapeContainer, Brushes.Blue);
                        com.Execute();
                        newShapeIndex++;
                        Render();
                    }
                    break;

                case Options.op.moveShape:

                    HitTestResult result = VisualTreeHelper.HitTest(Scene, Mouse.GetPosition(Scene));
                    Path path = result.VisualHit as Path;

                    if (path.Data.GetType() == typeof(RectangleGeometry))
                    {
                        int index = Convert.ToInt32(path.Tag.ToString());
                        GenericShape form = shapeContainer.shapes[index];

                        if (composite.children.Contains(form))
                        {
                            foreach (var pair in composite.children)
                            {
                                int indexGroup = Convert.ToInt32(pair.Shape.Tag);
                                ICommands com = new CommandMoveRect(dX, dY, indexGroup, shapeContainer, pair.Shape, Brushes.Blue);
                                com.Execute();
                            }
                        }
                        else{
                            ICommands com = new CommandMoveRect(dX, dY, index, shapeContainer, path, Brushes.Blue);
                            com.Execute();
                        }
                        Render();
                    }
                    break;

                case Options.op.groupShape:

                    ShapeComposite group = new ShapeComposite();

                    foreach (var pair in shapeContainer.shapes)
                    {
                        GenericShape temp = new GenericShape();
                        temp = pair.Value;
                        if ((temp.position.X > StartMovePoint.X) && (temp.position.Y > StartMovePoint.Y) && (temp.position.X < EndMovePoint.X) && (temp.position.Y < EndMovePoint.Y))
                        {
                            group.add(temp);
                            Scene.Children.Add(temp.Shape);
                        }

                        composite.add(group);
                       
                    }

                    Scene.Children.Remove(select.Shape);
                    break;
>>>>>>> f4eb00236e3d87d13397a5af887720ba989a9f50
            }
        }

        private void Scene_MouseMove(object sender, MouseEventArgs e)
        {
            double posX = e.GetPosition(Scene).X;
            double posY = e.GetPosition(Scene).Y;

<<<<<<< HEAD
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
=======
            switch (option.type)
            {
                case Options.op.newShape:
                    if (Mouse.LeftButton == MouseButtonState.Pressed)
                    {
                        if (shapeContainer.shapes.ContainsKey(newShapeIndex))
                        {
                            if (Scene.Children.Contains(tempForm))
                                Scene.Children.Remove(tempForm);

                            CommandSetSizeRect com = new CommandSetSizeRect(posX, posY, newShapeIndex, shapeContainer, Brushes.Blue);
                            com.Execute();
                            tempForm = com.getShape();
                            Scene.Children.Add(tempForm);
                        }
                    }
                    break;

                case Options.op.moveShape:
                    

                    if (Mouse.LeftButton == MouseButtonState.Pressed)
                    {
                        HitTestResult result = VisualTreeHelper.HitTest(Scene, Mouse.GetPosition(Scene));
                        Path path = result.VisualHit as Path;

                        int index = Convert.ToInt32(path.Tag.ToString());
                        GenericShape form = shapeContainer.shapes[index];

                        if (composite.children.Contains(form))
                        {
                            foreach (var pair in composite.children)
                            {
                                transform.Matrix = new Matrix(1, 0, 0, 1,
                                      posX - StartMovePoint.X,
                                      posY - StartMovePoint.Y);
                                pair.Shape.RenderTransform = transform;
                            }
                        }
                        else if(path != null)
                        {
                            transform.Matrix = new Matrix(1, 0, 0, 1,
                                 posX - StartMovePoint.X,
                                 posY - StartMovePoint.Y);
                            path.RenderTransform = transform;
                        }
                    }
                    break;

                case Options.op.groupShape:
                    if (Mouse.LeftButton == MouseButtonState.Pressed)
                    {
                            if (Scene.Children.Contains(select.Shape))
                                Scene.Children.Remove(select.Shape);

                            CommandSelectSize com = new CommandSelectSize(posX, posY, select, Brushes.Transparent);
                            com.Execute();
                            select.Shape = com.getShape();
                            Scene.Children.Add(select.Shape);
                        
                    }
                    break;
>>>>>>> f4eb00236e3d87d13397a5af887720ba989a9f50
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

<<<<<<< HEAD
       
    }

   
=======
        private void AddRectangle_Click(object sender, RoutedEventArgs e)
        {
            option.type = Options.op.newShape;
        }

        private void AddCircle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            option.type = Options.op.groupShape;
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            option.type = Options.op.moveShape;
        }

      

    }


>>>>>>> f4eb00236e3d87d13397a5af887720ba989a9f50


}
