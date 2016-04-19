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
    /// Lógica de interacción para facebookStatusUpdate.xaml
    /// </summary>
    public partial class facebookStatusUpdate : Window
    {
        private string _accessToken = "";
        private string status = "";
        public string Status { get { return status; } }

        public facebookStatusUpdate(string accessToken)
        {
            _accessToken = accessToken;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtStatusText.Text))
            {
                var fb = new FacebookClient(_accessToken);
                dynamic parametros = new System.Dynamic.ExpandoObject();
                parametros.message = txtStatusText.Text;
                try
                {
                    fb.Post("me/feed", parametros);
                }
                catch (Exception ex)
                {
                    new Warning("Hubo un error al intentar actualizar el status:\n" + ex.InnerException.Message);
                }
                this.Close();
            }
            else
            {
                new Warning("El campo de texto no puede quedar vacío").ShowDialog();
            }
        }
    }
}
