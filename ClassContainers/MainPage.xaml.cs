using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClassContainers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int _Rows;
        int _iCount;
        public MainPage()
        {
            this.InitializeComponent();
            _iCount = 0;
            _Rows = 5;
            createNineEllipses();

        }

        private void createNineEllipses()
        {
            for (int i = 0; i < _Rows; i++)
            {
                grdBoard.ColumnDefinitions.Add(new ColumnDefinition());
                grdBoard.RowDefinitions.Add(new RowDefinition());
            }
            //            < Ellipse x: Name = "el1" Fill = "RosyBrown" Grid.Column = "1" Grid.Row = "1" Height = "75" Width = "75" />
            Ellipse myEl;
            int iRow, iCol;
            // use R&C to name the objects
            for ( iRow = 0; iRow < _Rows; iRow++)
            {
                for ( iCol = 0; iCol < _Rows; iCol++)
                {
                    myEl = new Ellipse();
                    myEl.Name = "el_" + iRow + "_" + iCol;
                    myEl.Fill = new SolidColorBrush(Colors.RosyBrown);
                    myEl.Height = 50;
                    myEl.Width = 50;
                    myEl.SetValue(Grid.RowProperty, iRow);
                    myEl.SetValue(Grid.ColumnProperty, iCol);
                    // add event handler
                    myEl.Tapped += MyEl_Tapped;
                    grdBoard.Children.Add(myEl);
                }

            }
        }

        private void MyEl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Ellipse curr = (Ellipse)sender;
            //'curr.Fill = new SolidColorBrush(Colors.Red);
            ImageBrush brush = new ImageBrush();
            // imagebrush is an object
            // source is a bitmap image
            // bitmap image uses a URI as a path
            // can't find the file.
            // need another way - exists in the appx
            Uri uri = new Uri("ms-appx:///Images/Oogway.jpg", UriKind.RelativeOrAbsolute);
            BitmapImage bitmap = new BitmapImage(uri);

            brush.ImageSource = bitmap;
            curr.Fill = brush;

            // add an image here
            // fill - object
            // solid colour - solidcolorbrush
            // image - imagebrush
            _iCount++;
            tblCount.Text = _iCount.ToString();
            curr.Tapped -= MyEl_Tapped;
        }

        private void elReset_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // change all elipses back to rosy brown
            // need some way of looping throug all ellipses
            // on the grdBoard

            foreach (var item in grdBoard.Children )
            {
                // only ellipses in this
                if (item.GetType() == typeof(Ellipse))
                {
                    //((Ellipse)item).Fill = 
                    //    new SolidColorBrush(Colors.RosyBrown);
                    grdBoard.Children.Remove(item);
                }
            }


        }
    }
}
