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

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para genericNavigator.xaml
    /// </summary>
    public partial class genericNavigator : Window
    {
        private string embedLink;
        private Uri youtubeLink;

        public genericNavigator(string videoId, Uri youtubeLink)
        {
            InitializeComponent();
            embedLink = "http://www.youtube.com/embed/" + videoId;
            this.youtubeLink = youtubeLink;
            wbGeneric.Navigate(embedLink);
        }

        private void tbkViewOnYoutube_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(youtubeLink.ToString());
        }

        private void tbkCerrar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wbGeneric.Navigate("about:blank");
            this.Close();
        }
    }
}
