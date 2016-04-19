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
using Facebook;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para facebookGenericUpdate.xaml
    /// </summary>
    public partial class facebookGenericUpdate : Window
    {
        private string accessToken = "";
        public string _accessToken { private get { return accessToken; } set { accessToken = value; } }

        public facebookGenericUpdate(string accessToken)
        {
            this.accessToken = accessToken;
            InitializeComponent();
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new facebookStatusUpdate(accessToken).ShowDialog();
            this.Close();
        }

        private void btnPicture_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Archivos de imagen JPEG|*.jpg";
            ofd.Title = "SNM";
            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                new Warning("No se seleccionó exitosamente una imagen para subir");
                return;
            }
            var fb = new FacebookClient(_accessToken);
            dynamic parametros = new System.Dynamic.ExpandoObject();
            parametros.source = new FacebookMediaObject
            {
                ContentType = "image/jpeg",
                FileName = System.IO.Path.GetFileName(ofd.FileName)
            }.SetValue(System.IO.File.ReadAllBytes(ofd.FileName));
            this.Hide();
            try
            {
                fb.Post("me/photos", parametros);
                new Warning("La imagen fue subida exitosamente, pronto estará disponible");
            }
            catch (Exception ex)
            {
                new Warning("Hubo un error al intentar subir el video a facebook\n" + ex.InnerException.Message);
            }
            this.Close();
        }

        private void btnVideo_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Archivos de video MP4|*.mp4";
            ofd.Title = "SNM";
            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                new Warning("No se seleccionó exitosamente un video para subir");
                return;
            }
            var fb = new FacebookClient(_accessToken);
            dynamic parametros = new System.Dynamic.ExpandoObject();
            parametros.source = new FacebookMediaObject
            {
                ContentType = "video/mp4",
                FileName = System.IO.Path.GetFileName(ofd.FileName)
            }.SetValue(System.IO.File.ReadAllBytes(ofd.FileName));
            this.Hide();
            try
            {
                fb.Post("me/videos", parametros);
                new Warning("El video fue subido exitosamente\nFacebook lo procesará y publicará cuando este listo");
            }
            catch (Exception ex)
            {
                new Warning("Hubo un error al intentar subir el video a facebook\n" + ex.InnerException.Message);
            }
            this.Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
