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
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Extensions.MediaRss;
using Google.GData.YouTube;
using Google.YouTube;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para youtubeGenericList.xaml
    /// </summary>
    public partial class youtubeGenericList : Window
    {
        public youtubeGenericList(Feed<Video> genericVideoFeed)
        {
            InitializeComponent();
            foreach (Video sub in genericVideoFeed.Entries)
            {
                lstGenericVideos.Items.Add(new userControlYoutubeVideoEntry(sub));
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
