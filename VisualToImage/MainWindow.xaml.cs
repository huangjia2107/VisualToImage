using System;
using System.Collections.Generic;
using System.IO;
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

namespace VisualToImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var fs = new FileStream("d:/aaa.png", FileMode.Create, FileAccess.ReadWrite))
            {
                /*
                var drawingVisual = new DrawingVisual();
                var width = Element.ActualWidth;
                var height = Element.ActualHeight;

                using (var context = drawingVisual.RenderOpen())
                {
                    var contentBounds = VisualTreeHelper.GetDescendantBounds(Element);
                    context.DrawRectangle(new VisualBrush(Element) { Stretch = Stretch.Fill, Viewbox = new Rect(0, 0, width / contentBounds.Width, height / contentBounds.Height) }, null, new Rect(0, 0, width, height));
                }
                */
                var renderSize = ssss.RenderSize;

                ssss.Measure(renderSize);
                ssss.Arrange(new Rect(renderSize));

                var rtb = new RenderTargetBitmap((int)renderSize.Width, (int)renderSize.Height, 96, 96, PixelFormats.Default);
                rtb.Render(ssss);

                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                encoder.Save(fs);

                //restore
                var parent = VisualTreeHelper.GetParent(ssss as DependencyObject) as UIElement;
                ssss.Measure(parent.RenderSize);
                ssss.Arrange(new Rect(parent.RenderSize));
            }
        }
    }
}
