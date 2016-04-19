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
    /// Lógica de interacción para twitterVerificationPinForm.xaml
    /// </summary>
    public partial class twitterVerificationPinForm : Window
    {
        private const string consumerKey = "hGLgKpwW5xEpU7ZdRyGnA"; //twitter
        private const string consumerSecret = "274wgmUd3v7MkWnMauDQrjIs8k30ppmCZ2nQxKmKWI"; //twitter
        private OAuthTokens _tokens;
        public OAuthTokens tokens { get { return _tokens; } }
        private decimal _homeUserId;
        public decimal homeUserId { get { return _homeUserId; } }
        private TwitterUser _homeUser;
        public TwitterUser homeUser { get { return _homeUser; } }
        private OAuthTokenResponse requestToken;
        private Warning advertencia;
        private string _error = "";
        public string error { get { return _error; } }

        public twitterVerificationPinForm()
        {
            InitializeComponent();
        }

        private void btnPIN_Click(object sender, RoutedEventArgs e)
        {
            if (validPIN(txtPIN.Text))
            {
                try
                {
                    _tokens = returnTokens(txtPIN.Text, requestToken);
                    this.Close();
                }
                catch (Exception)
                {
                    new Warning("Hubo un error al intentar ingresar a la cuenta de twitter").ShowDialog();
                    _error = "error desconocido";
                    this.Close();
                }
            }
        }

        private void txtPIN_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (txtPIN.Text.Length == 7)
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        e.Handled = true;
                        btnPIN_Click(sender, e);
                        break;
                    case Key.Back:
                        break;
                    default:
                        e.Handled = true;
                        advertencia = new Warning("El pin está conformado solo por 7 dígitos");
                        advertencia.ShowDialog();
                        break;
                }
            }
        }

        private OAuthTokens returnTokens(string codigo, OAuthTokenResponse requestToken)
        {
            OAuthTokenResponse accessToken = OAuthUtility.GetAccessToken(consumerKey, consumerSecret, requestToken.Token, codigo);
            _homeUserId = accessToken.UserId;
            TwitterResponse<TwitterUser> respuestaAusuario = TwitterUser.Show(_homeUserId);
            _homeUser = respuestaAusuario.ResponseObject;
            OAuthTokens tokens = new OAuthTokens();
            tokens.AccessToken = accessToken.Token;
            tokens.AccessTokenSecret = accessToken.TokenSecret;
            tokens.ConsumerKey = consumerKey;
            tokens.ConsumerSecret = consumerSecret;
            return tokens;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            requestToken = OAuthUtility.GetRequestToken(consumerKey, consumerSecret, "oob");
            Uri authorizationUri = OAuthUtility.BuildAuthorizationUri(requestToken.Token, false);
            string autorizationUrl = authorizationUri.ToString();
            System.Diagnostics.Process.Start(autorizationUrl);
        }

        private bool validPIN(string cadena)
        {
            if (cadena.Length == 7)
            {
                foreach (char caracter in cadena.ToCharArray())
                {
                    if (!char.IsDigit(caracter))
                    {
                        advertencia = new Warning("El pin no puede contener ningun caracter que no sea un dígito");
                        advertencia.ShowDialog();
                        return false;
                    }
                }
                return true;
            }
            else
            {
                advertencia = new Warning("El pin está conformado por 7 dígitos");
                advertencia.ShowDialog();
                return false;
            }
        }
    }
}
