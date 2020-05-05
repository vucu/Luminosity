using Luminosity.Utils;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Luminosity
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

        private void OnPasteFromClipboard(object sender, RoutedEventArgs e)
        {
            var image = ClipboardUtils.ImageFromClipboardDib().AsWriteable();
            MyImage.Source = image;

            if (MyCanvas.Width < image.Width)
            {
                MyCanvas.Width = image.Width;
                MyCanvas.Height = MyCanvas.Width * 1.6;
            }
            if (MyCanvas.Height < image.Height)
            {
                MyCanvas.Height = image.Width;
                MyCanvas.Width = Math.Round(MyCanvas.Height / 1.6);
            }

            var w = MyCanvas.Width;
            var h = MyCanvas.Height;
            var x = Math.Round((w - image.Width) / 2);
            var y = Math.Round((h - image.Height) / 2);
            Canvas.SetLeft(MyImage, x);
            Canvas.SetTop(MyImage, y);
            var wport = MyScrollViewer.ViewportWidth;
            var hport = MyScrollViewer.ViewportHeight;
            var xport = Math.Round((w - wport) / 2);
            var yport = Math.Round((h - hport) / 2);
            MyScrollViewer.ScrollToHorizontalOffset(xport);
            MyScrollViewer.ScrollToVerticalOffset(yport);
        }
    }
}
