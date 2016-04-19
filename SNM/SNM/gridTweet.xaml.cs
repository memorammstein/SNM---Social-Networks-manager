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
using Twitterizer;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para ListboxItem.xaml
    /// </summary>
    public partial class gridTweet : Grid
    {
        private string statusLink = "";
        private string sourceLink = "";
        private string avatarLink = "";
        private TwitterStatus tuit;
        private OAuthTokens tokens;
        private TwitterUser homeUser;

        public gridTweet(TwitterStatus tweet, OAuthTokens tokens, TwitterUser homeUser)
        {
            InitializeComponent();
            tuit = tweet;
            this.tokens = tokens;
            this.homeUser = homeUser;
            constructor();
        }

        private void constructor()
        {
            TwitterUser usuario = tuit.User;
            //retweet o no
            if (tuit.Text.Contains("RT @"))
            {
                TwitterStatus tweetRetweeteado = tuit.RetweetedStatus;
                TwitterUser usuarioRetweeteado = tweetRetweeteado.User;
                avatar.Source = new BitmapImage(new Uri(usuarioRetweeteado.ProfileImageLocation, UriKind.Absolute));
                avatarLink = usuarioRetweeteado.ProfileImageLocation;
                tbkSreenName.Text = usuarioRetweeteado.ScreenName;
                tbkFullName.Text = usuarioRetweeteado.Name;
                tbkStatus.Text = tweetRetweeteado.Text;
                avatarRetweeted.Source = new BitmapImage(new Uri(usuario.ProfileImageLocation, UriKind.Absolute));
                retweetedScreenName.Text = "RT: " + usuario.ScreenName;
                if (usuarioRetweeteado.Verified == true)
                {
                    stkScreenNames.Children.Insert(0, new verifiedImage());
                }
                if (usuario.Verified == true)
                {
                    stkRetweeted.Children.Add(new verifiedImage());
                }
            }
            else
            {
                avatar.Source = new BitmapImage(new Uri(usuario.ProfileImageLocation, UriKind.Absolute));
                avatarLink = usuario.ProfileImageLocation;
                tbkSreenName.Text = usuario.ScreenName;
                tbkFullName.Text = usuario.Name;
                tbkStatus.Text = tuit.Text;
                avatarRetweeted.Visibility = System.Windows.Visibility.Hidden;
                retweetedScreenName.Visibility = System.Windows.Visibility.Hidden;
                if (usuario.Verified == true)
                {
                    stkScreenNames.Children.Insert(0, new verifiedImage());
                }
            }
            int nuevaslineas = CharOccurs(tbkStatus.Text, '\n');
            grdTweet.Height = grdTweet.Height + (15 * nuevaslineas);
            //retweet o no
            tbkDate.Text = tuit.CreatedDate.ToString();
            statusLink = "http://twitter.com/" + tuit.User.ScreenName + "/statuses/" + tuit.Id.ToString();
            string hyperSource = tuit.Source;
            if (hyperSource == "web")
            {
                sourceLink = "http://twitter.com/";
                tbkSource.Text = hyperSource;
            }
            else
            {
                string source = hyperSource;
                source = source.Remove(0, 9);
                source = source.Replace("\" rel=\"nofollow\">", "$");
                source = source.Replace("</a>", "");
                char[] separador = { '$' };
                string[] linkANDsource = source.Split(separador);
                sourceLink = linkANDsource[0];
                tbkSource.Text = linkANDsource[1];
            }
        }

        private void tbkDate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(statusLink);
        }

        private void favorito_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TwitterFavorite.Create(tokens, tuit.Id);
            new Warning("Tweet\nFavoriteado\nExitosamente").ShowDialog();
        }

        private void respuesta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StatusUpdateOptions opciones = new StatusUpdateOptions();
            opciones.InReplyToStatusId = tuit.Id;
            Update respuesta = new Update(tokens, homeUser, "@" + tuit.User.ScreenName, opciones);
            respuesta.ShowDialog();
        }

        private void retweet_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tuit.Retweet(tokens);
            new Warning("Tweet\nRetuiteado\nExitosamente").ShowDialog();
        }

        public static int CharOccurs(string stringToSearch, char charToFind)
        {
            int count = 0;
            char[] chars = stringToSearch.ToCharArray();
            foreach (char c in chars)
            {
                if (c == charToFind)
                {
                    count++;
                }
            }
            return count;
        }

        private void tbkSource_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(sourceLink);
        }

        private void avatar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (avatarLink.Contains("_normal"))
            {
                avatarLink = avatarLink.Remove(avatarLink.IndexOf("_normal",avatarLink.Length-12),7);
            }
            new uriVisual(new Uri(avatarLink, UriKind.Absolute)).ShowDialog();
        }

        private void tbkSreenName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitter.com/#!/" + tbkSreenName.Text);
        }
    }
}
