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
using System.Windows.Shapes;
using System.Net;
using System.IO;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para uriVisual.xaml
    /// </summary>
    public partial class uriVisual : Window
    {
        public uriVisual(Uri uriImagen)
        {
            InitializeComponent();
            var bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(new WebClient().DownloadData(uriImagen));
            bi.EndInit();
            uriVisualizerImage.Source = bi;
            uriVisualizerImage.Width = uriVisualizerImage.Source.Width;
            uriVisualizerImage.Height = uriVisualizerImage.Source.Height;
            if (uriVisualizerImage.Width < 150)
            {
                frmBrowser.MinWidth = 150 + 17;
                frmBrowser.Width = 150 + 17;
            }
            else
            {
                frmBrowser.MinWidth = uriVisualizerImage.Width + 17;
                frmBrowser.Width = uriVisualizerImage.Width + 17;
            }
            if (uriVisualizerImage.Height < 150)
            {
                frmBrowser.MinHeight = 150 + 38;
                frmBrowser.Height = 150 + 38;
            }
            else
            {
                frmBrowser.MinHeight = uriVisualizerImage.Height + 38;
                frmBrowser.Height = uriVisualizerImage.Height + 38;
            }
        }
    }
}
