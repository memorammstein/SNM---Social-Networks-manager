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
using Google.YouTube;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para userControlYoutubeVideoEntry.xaml
    /// </summary>
    public partial class userControlYoutubeVideoEntry : UserControl
    {
        private Video video;

        public userControlYoutubeVideoEntry(Video video)
        {
            InitializeComponent();
            this.video = video;
            tbkTitle.Text = video.Title;
            tbkUploader.Text = video.Uploader;
            tbkViewCount.Text = video.ViewCount.ToString() + " reproducciones";
            txtDescripcion.Text = video.Description;
            int counter = 0;
            foreach (Google.GData.Extensions.MediaRss.MediaThumbnail thumbnail in video.Thumbnails)
            {
                if (counter == 0)
                {
                    counter++;
                }
                else if (counter == 1)
                {
                    mainImage.Source = new BitmapImage(new Uri(thumbnail.Url, UriKind.Absolute));
                    counter++;
                }
                else
                {
                    Image videoImage = new Image();
                    videoImage.Source = new BitmapImage(new Uri(thumbnail.Url, UriKind.Absolute));
                    videoImage.Margin = new Thickness(0,0,10,0);
                    stkImages.Children.Add(videoImage);
                    counter++;
                }
            }
            foreach (Google.GData.YouTube.MediaContent mediaContent in video.Contents)
            {
                double duracion = Convert.ToDouble(mediaContent.Duration);
                double minutos = Math.Truncate(duracion / 60);
                double segundos = duracion % 60;
                if (segundos < 10)
                {
                    tbkDuration.Text = String.Format("{0}:0{1}", minutos, segundos);
                }
                else
                {
                    tbkDuration.Text = String.Format("{0}:{1}", minutos, segundos);
                }
            }
        }

        private void mainImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                new frmFlashPlayerEmbeded(video.VideoId, video.WatchPage).ShowDialog();
            }
            catch (Exception)
            {
                new genericNavigator(video.VideoId, video.WatchPage).ShowDialog();
            }
        }
    }
}
