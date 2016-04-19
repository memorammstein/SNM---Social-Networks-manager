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
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para youtubeUploader.xaml
    /// </summary>
    public partial class youtubeUploader : Window
    {
        private YouTubeRequest request;
        public YouTubeRequest Request { private get { return request; } set { request = value; } }
        private string rutaDeArchivo;
        private string extensionDeArchivo;
        private string tipoDeArchivo;

        public youtubeUploader(YouTubeRequest request)
        {
            this.request = request;
            InitializeComponent();
        }

        public void UploadVideo()
        {
            var videoToUpload = new Video();
            videoToUpload.Title = txtTitulo.Text;
            videoToUpload.Tags.Add(new MediaCategory(cmbCategorias.SelectedItem.ToString(), YouTubeNameTable.CategorySchema));
            videoToUpload.Keywords = txtPalabrasClave.Text;
            videoToUpload.Description = txtDescripcion.Text;
            GetFileMime();
            videoToUpload.MediaSource = new MediaFileSource(rutaDeArchivo, tipoDeArchivo);
            try
            {
                request.Upload(videoToUpload);
                new Warning("El video se subio exitosamente").ShowDialog();
                this.Close();
            }
            catch (Exception e)
            {
                new Warning(e.InnerException.Message).ShowDialog();
            }
        }

        public void GetFileMime()
        {
            switch (extensionDeArchivo)
            {
                case "flv":
                    tipoDeArchivo = "video/x-flv";
                    break;
                case "avi":
                    tipoDeArchivo = "video/avi";
                    break;
                case "3gp":
                    tipoDeArchivo = "video/3gpp";
                    break;
                case "mov":
                    tipoDeArchivo = "video/quicktime";
                    break;
                default:
                    tipoDeArchivo = "video/quicktime";
                    break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void btnSubir_Click(object sender, RoutedEventArgs e)
        {
            var legalWarning = new youtubeLegal();
            legalWarning.ShowDialog();
            if (legalWarning.Accept)
            {
                UploadVideo();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBuscarArchivo_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.ShowDialog();
            txtArchivo.Text = ofd.FileName;
            rutaDeArchivo = ofd.FileName.Replace("\\", "\\\\");
            extensionDeArchivo = ofd.FileName.Split('\\')[ofd.FileName.Split('\\').GetUpperBound(0)].Split('.')[1];
        }
    }
}
