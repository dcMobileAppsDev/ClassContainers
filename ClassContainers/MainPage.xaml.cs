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
                    myEl.Height = 75;
                    myEl.Width = 75;
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
            curr.Fill = new SolidColorBrush(Colors.Red);
            _iCount++;
            tblCount.Text = _iCount.ToString();
            curr.Tapped -= MyEl_Tapped;
        }
    }
}
