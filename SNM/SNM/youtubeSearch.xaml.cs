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
    /// Lógica de interacción para youtubeSearch.xaml
    /// </summary>
    public partial class youtubeSearch : Window
    {
        private YouTubeRequest request;

        public youtubeSearch(YouTubeRequest request)
        {
            this.request = request;
            InitializeComponent();
        }

        private void txtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);
                query.OrderBy = "viewCount";
                query.Query = txtSearch.Text;
                query.SafeSearch = YouTubeQuery.SafeSearchValues.None;
                this.Hide();
                try
                {
                    new youtubeGenericList(request.Get<Video>(query)).ShowDialog();
                }
                catch (Exception)
                {
                    new Warning("Hubo un error en la búsqueda o no se encontró ningún resultado").ShowDialog();
                }
                this.Close();
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
