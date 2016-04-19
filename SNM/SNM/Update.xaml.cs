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
using Twitterizer;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public Update(OAuthTokens tokens, TwitterUser usuario)
        {
            InitializeComponent();
            this.tokens = tokens;
            this.reply = false;
            this.usuario = usuario;
            updateOwnerAvatar.Source = new BitmapImage(new Uri(this.usuario.ProfileImageLocation, UriKind.Absolute));
            tbkupdateOwner.Text = "@" + this.usuario.ScreenName;
        }

        public Update(OAuthTokens tokens, TwitterUser usuario, string replyUserScreenName, StatusUpdateOptions replyUserId)
        {
            InitializeComponent();
            this.tokens = tokens;
            this.reply = true;
            this.usuario = usuario;
            updateOwnerAvatar.Source = new BitmapImage(new Uri(this.usuario.ProfileImageLocation, UriKind.Absolute));
            tbkupdateOwner.Text = "@" + this.usuario.ScreenName;
            txtUpdate.Text = replyUserScreenName + " ";
            this.replyUserId = replyUserId;
        }

        private int caracteresDisponibles = 140;
        private bool reply;
        private StatusUpdateOptions replyUserId;
        private OAuthTokens tokens;
        private TwitterUser usuario;

        private void txtUpdate_TextChanged(object sender, TextChangedEventArgs e)
        {
            caracteresDisponibles = 140 - txtUpdate.Text.Length;
            tbkCaracteresRestantes.Text = caracteresDisponibles.ToString();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUpdate.Text.Length <= 140)
            {
                if (reply)
                {
                    TwitterResponse<TwitterStatus> replyResult = TwitterStatus.Update(tokens, txtUpdate.Text, replyUserId);
                    if (replyResult.Result == RequestResult.Success)
                    {
                        Warning aviso = new Warning("el tweet fue respondido exitosamente");
                        aviso.ShowDialog();
                    }
                    else
                    {
                        Warning aviso = new Warning("el tweet no pudo ser respondido");
                        aviso.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    TwitterResponse<TwitterStatus> postResult = TwitterStatus.Update(tokens, txtUpdate.Text);
                    if (postResult.Result == RequestResult.Success)
                    {
                        Warning aviso = new Warning("el tweet fue enviado exitosamente");
                        aviso.ShowDialog();
                    }
                    else
                    {
                        Warning aviso = new Warning("el tweet no pudo ser enviado ser enviado");
                        aviso.ShowDialog();
                    }
                    this.Close();
                }
            }
        }
    }
}
