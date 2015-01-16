using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;

namespace Boltz
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
	private void ClearViewport()
	{
    		/*ModelVisual3D m;
    		for (int i = Viewport1.Children.Count - 1; i >= 0; i--)
    		{
        		m = (ModelVisual3D)Viewport1.Children[i];
        		if (m.Content is DirectionalLight == false)
            	Viewport1.Children.Remove(m);
    		}*/
            output.Clear();
	}

        private void submit_button_Click(object sender, RoutedEventArgs e)
        {
            output.IsReadOnly = false;
            double bolts = 0.0;
            double radius = 0.0;

            radius = double.Parse(Radius.Text);
            bolts = double.Parse(number_bolts.Text);

            //Cos is in radians so use 2pi, Sin is also radians
            double total_radians = 2 * System.Math.PI;
            double radians_per_bolt = Math.Round(total_radians / bolts, 4);

            double x = 0.0;
            double y = 0.0;

            double deltax = 0.0;
            double deltay = 0.0;
            double diam = 0.0;

            string resul = "";
            List<double> xs = new List<double>();
            List<double> ys = new List<double>();

            for (double i = 1.0; i <= bolts; i++)
            {
                x = radius * Math.Round(System.Math.Cos(radians_per_bolt * i), 4);
                y = radius * Math.Round(System.Math.Sin(radians_per_bolt * i), 4);
                resul = resul + "X: " + x.ToString() + "   " + "Y: " + y.ToString() + "\r\n";
                xs.Add(x);
                ys.Add(y);
            }

                //sqrt(Deltax^2 + Deltay^2)
            //Calculate the max diameter here!!!!!!!!!!
            deltax = xs.ElementAt<double>(1) - xs.ElementAt<double>(0);
            deltay = ys.ElementAt<double>(1) - ys.ElementAt<double>(0);
            diam = Math.Round(Math.Sqrt((deltax * deltax) + (deltay * deltay)), 4); //Pythagorean Theorem :D
            MaxRadValue.IsReadOnly = false;

            MaxRadValue.Text = diam.ToString();

                output.Text = resul;
                output.IsReadOnly = true;

                

                
                //Code to Generate Model Here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                MeshGeometry3D mesh1 = (MeshGeometry3D)Grid1.Resources["MeshGeometry3D1"];
                int element = 0;
                mesh1.Positions.Add(new Point3D(0, 0, 10.0));
                int counter3D = 0;
                foreach(double xl in xs)
                {
                    mesh1.Positions.Add(new Point3D(xl, ys.ElementAt(element), 10.0));
                    element++;
                    counter3D++;
                    if (counter3D == 2)
                    {
                        mesh1.Positions.Add(new Point3D(0, 0, 10.0));
                        counter3D = 0;
                    }
                }
                int counter = 0;
                foreach (Point3D vert in mesh1.Positions)
                {
                    mesh1.TriangleIndices.Add(counter);
                    counter++;
                }
                
        }

        private void sliderx_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PerspectiveCamera camera = (PerspectiveCamera)Viewport1.Camera;
            Point3D newPos = new Point3D(camera.Position.X - 5*e.OldValue + 5*e.NewValue, camera.Position.Y, camera.Position.Z);
            camera.Position = newPos;
        }

        private void slidery_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PerspectiveCamera camera = (PerspectiveCamera)Viewport1.Camera;
            Point3D newPos = new Point3D(camera.Position.X, camera.Position.Y - 5*e.OldValue + 5*e.NewValue, camera.Position.Z);
            camera.Position = newPos;
        }

        private void sliderz_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PerspectiveCamera camera = (PerspectiveCamera)Viewport1.Camera;
            Point3D newPos = new Point3D(camera.Position.X, camera.Position.Y, camera.Position.Z - 5*e.OldValue + 5*e.NewValue);
            camera.Position = newPos;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClearViewport();
            sliderx.Value = 0;
            slidery.Value = 0;
            sliderz.Value = 0;
            MeshGeometry3D mesh1 = (MeshGeometry3D)Grid1.Resources["MeshGeometry3D1"];
            mesh1.Positions.Clear();
            mesh1.TriangleIndices.Clear();
            mesh1.Normals.Clear();
            mesh1.TextureCoordinates.Clear();
            PerspectiveCamera camera = (PerspectiveCamera)Viewport1.Camera;
            camera.Position = new Point3D(10, 10, 15);
 
        }
    }
}
