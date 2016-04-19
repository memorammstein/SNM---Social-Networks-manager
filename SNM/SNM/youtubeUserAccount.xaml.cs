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
using Google.YouTube;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para youtubeUserAccount.xaml
    /// </summary>
    public partial class youtubeUserAccount : Window
    {
        private const string developerKey = "AI39si6q7voAYhO_soOlSHk1rBYgZtmAhpqwAhml4bpIQfbO8SZuXwUh9fAfHus3n8JuF1JVJIXiIQbcXv_igoG3badlqx03jA";
        private YouTubeRequest _request;
        public YouTubeRequest request { get { return _request; } }

        public youtubeUserAccount()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtGmail.Text))
            {
                new Warning("ha dejado el campo de correo electrónico vacío").ShowDialog();
                return;
            }
            else if (String.IsNullOrEmpty(PassPassword.Password))
            {
                new Warning("ha dejado el campo de la contraseña vacío").ShowDialog();
                return;
            }
            YouTubeRequestSettings settings = new YouTubeRequestSettings("social-networks-manager", developerKey,
                txtGmail.Text + "@gmail.com", PassPassword.Password);
            _request = new YouTubeRequest(settings);
            this.Close();
        }

        private void txtGmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Contains('@'))
            {
                e.Handled = true;
            }
        }

        private void txtGmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnEnviar_Click(sender, e);
            }
        }

        private void PassPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnEnviar_Click(sender, e);
            }
        }
    }
}
