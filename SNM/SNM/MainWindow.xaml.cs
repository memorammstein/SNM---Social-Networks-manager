using System;
using System.Collections.Generic;
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
using Facebook;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Extensions.MediaRss;
using Google.GData.YouTube;
using Google.YouTube;

namespace SNM
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        #region variables pricipales
        private OAuthTokens tokens;
        private TwitterUser usuarioTwitter;
        private YouTubeRequest request;
        private string _accessToken;
        private bool twitterActivated = false;
        private bool facebookActivated = false;
        private bool youtubeActivated = false;
        #endregion

        public MainWindow()
		{
			InitializeComponent();
		}

        private void iconFacebookImg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbkStatus.Text = "Ingresando a Facebook";
            const string AppId = "158937177535377";
            const string ExtendedPermissions = "user_about_me,publish_stream,offline_access,read_stream,user_photos,user_videos";
            var frmFacebookLogin = new facebookLoginForm(AppId, ExtendedPermissions);
            frmFacebookLogin.ShowDialog();
            if (frmFacebookLogin.FacebookOAuthResult.IsSuccess)
            {
                _accessToken = frmFacebookLogin.FacebookOAuthResult.AccessToken;
                iconFacebookImg.Source = new BitmapImage(new Uri("Iconos/facebook_64.png", UriKind.Relative));
                tbkStatus.Text = "";
                facebookActivated = true;
            }
            else
            {
                tbkStatus.Text = "Error al intentar ingresar a la cuenta de facebook: "
                    + frmFacebookLogin.FacebookOAuthResult.ErrorReason + "\n intentalo de nuevo";
                facebookActivated = false;
            }
            
        }

        private void iconTwitterImg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbkStatus.Text = "Ingresando a Twitter";
            twitterVerificationPinForm verification = new twitterVerificationPinForm();
            verification.ShowDialog();
            if (verification.error == "")
            {
                tokens = verification.tokens;
                usuarioTwitter = verification.homeUser;
                iconTwitterImg.Source = new BitmapImage(new Uri("Iconos/twitter_64.png", UriKind.Relative));
                tbkStatus.Text = "";
                twitterActivated = true;
            }
            else
            {
                tbkStatus.Text = "No se pudo ingresar exitosamente a Twitter\n intenta de nuevo";
                twitterActivated = false;
            }
            
        }

        private void iconYoutubeImg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbkStatus.Text = "Ingresando a Youtube";
            youtubeUserAccount requester = new youtubeUserAccount();
            requester.ShowDialog();
            request = requester.request;
            try
            {
                Feed<Video> subsFeedTest = request.Get<Video>
                    (new Uri("http://gdata.youtube.com/feeds/api/users/default/newsubscriptionvideos?&max-results=1"));
                foreach (Video sub in subsFeedTest.Entries) { }
            }
            catch (Exception ice)
            {
                tbkStatus.Text = "Error al intentar ingresar a la cuenta de youtube: " + ice.Message
                    + "\n intentalo de nuevo";
                youtubeActivated = false;
                return;
            }
            iconYoutubeImg.Source = new BitmapImage(new Uri("Iconos/youtube_64.png", UriKind.Relative));
            tbkStatus.Text = "";
            youtubeActivated = true;
        }

        private void txtUsername_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void txtUsername_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "")
            {
                tbkStatus.Text = "El campo del nombre de usuario no puede quedar vacío";
                return;
            }
            if (!facebookActivated && !twitterActivated && !youtubeActivated)
            {
                tbkStatus.Text =
                    "No agregaste exitosamente ninguna red social" + "\n"
                    + "por favor, activa por lo menos una red social e intenta de nuevo";
                return;
            }
            foreach (TabItem item in tabUsuarios.Items)
            {
                if (txtUsername.Text == item.Name)
                {
                    tbkStatus.Text =
                        "Ya existe una pestaña con ese nombre de usuario" + "\n"
                        + "por favor, elige otro nombre de usuario";
                    return;
                }
            }
            tbkStatus.Text = "Inicializando la aplicación\npor favor, espere...";
            TabItem usuario = new TabItem();
            usuario.Header = txtUsername.Text;
            usuario.Name = txtUsername.Text;
            multiManager multimanager = new multiManager(facebookActivated, twitterActivated, youtubeActivated);
            multimanager.HomeUser = usuarioTwitter;
            multimanager.AccessToken = _accessToken;
            multimanager.TwitterTokens = tokens;
            multimanager.YoutubeRequest = request;
            multimanager.initializeMultiManager();
            multimanager.Name = "multiManager" + txtUsername.Text;
            usuario.Content = multimanager;
            tabUsuarios.Items.Add(usuario);
            tabUsuarios.SelectedIndex = tabUsuarios.Items.Count - 1;
            newUser();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUsername.Text != "")
            {
                iconFacebookImg.Visibility = System.Windows.Visibility.Visible;
                iconTwitterImg.Visibility = System.Windows.Visibility.Visible;
                iconYoutubeImg.Visibility = System.Windows.Visibility.Visible;
                btnAgregar.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void frmSNM_Loaded(object sender, RoutedEventArgs e)
        {
            newUser();
        }

        private void newUser()
        {
            twitterActivated = false;
            facebookActivated = false;
            youtubeActivated = false;
            iconFacebookImg.Visibility = System.Windows.Visibility.Hidden;
            iconTwitterImg.Visibility = System.Windows.Visibility.Hidden;
            iconYoutubeImg.Visibility = System.Windows.Visibility.Hidden;
            btnAgregar.Visibility = System.Windows.Visibility.Hidden;
            iconFacebookImg.Source = new BitmapImage(new Uri("Iconos/facebook_64_off.png", UriKind.Relative));
            iconTwitterImg.Source = new BitmapImage(new Uri("Iconos/twitter_64_off.png", UriKind.Relative));
            iconYoutubeImg.Source = new BitmapImage(new Uri("Iconos/youtube_64_off.png", UriKind.Relative));
            tbkStatus.Text = "";
            txtUsername.Text = "";
        }
	}
}