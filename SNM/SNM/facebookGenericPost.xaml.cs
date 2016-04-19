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
using Facebook;
using System.Net;
using System.IO;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para facebookGenericPost.xaml
    /// </summary>
    public partial class facebookGenericPost : UserControl
    {
        string _accessToken = "";
        dynamic post;
        dynamic fromUser;

        public facebookGenericPost(dynamic facebookPost, string _accessToken)
        {
            InitializeComponent();
            post = facebookPost;
            this._accessToken = _accessToken;
            string userId = post.from.id;
            string pictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}", userId, "square");
            userPicture.Source = new BitmapImage(new Uri(pictureUrl));
            var fb = new FacebookClient(this._accessToken);
            fromUser = fb.Get(userId);
            tbkUserName.Text = fromUser.name;
            if (fromUser.ContainsKey("username"))
            {
                tbkUserUsername.Text = fromUser.username;
            }
            else
            {
                tbkUserUsername.Text = "";
            }
            if (post.ContainsKey("story"))
            {
                tbkContent.Text = post.story;
                if (post.ContainsKey("message"))
                {
                    tbkContent.Text = tbkContent.Text + "\n\n" + post.message;
                }
            }
            else if (post.ContainsKey("message"))
            {
                tbkContent.Text = post.message;
            }
            else
            {
                tbkContent.Text = "";
            }
            if (post.ContainsKey("icon"))
            {
                string iconUrl = post.icon;
                var icono = new BitmapImage(new Uri(iconUrl, UriKind.Absolute));
                var imagenIcono = new Image();
                imagenIcono.Source = icono;
                imagenIcono.Margin = new Thickness(0, 0, 10, 0);
                stkData.Children.Insert(0, imagenIcono);
            }
            string date = post.created_time;
            char[] separadores = { '-','T','+',':' };
            string[] partesDeFecha = date.Split(separadores,StringSplitOptions.RemoveEmptyEntries);
            int año = Convert.ToInt32(partesDeFecha[0]);
            int mes = Convert.ToInt32(partesDeFecha[1]);
            int dia = Convert.ToInt32(partesDeFecha[2]);
            int hora = Convert.ToInt32(partesDeFecha[3]);
            int minuto = Convert.ToInt32(partesDeFecha[4]);
            int segundo = Convert.ToInt32(partesDeFecha[5]);
            var postDate = new DateTime(año, mes, dia, hora, minuto, segundo, DateTimeKind.Utc);
            postDate = postDate.ToLocalTime();
            string fixedDate = postDate.ToLongDateString() + "   " + postDate.ToLongTimeString();
            tbkDate.Text = fixedDate;
            if (post.comments.count != 0)
            {
                stkComments.Margin = new Thickness(0, 10, 0, 10);
                foreach (dynamic comment in post.comments.data)
                {
                    stkComments.Children.Add(new facebookComment(comment));
                }
            }
            if (post.type != "status")
            {
                stkPersonalizedControl.Children.Add(new facebookGenericContent(post));
            }
        }

        private void userPicture_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("www.facebook.com/" + post.from.id);
        }

        private void tbkUserName_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("www.facebook.com/" + post.from.id);
        }

        private void tbkDate_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(post.actions[0].link);
            }
            catch (Exception)
            {
                System.Diagnostics.Process.Start
                    ("www.facebook.com/" + post.id.Remove(0, post.id.IndexOf('_', 0) + 1));
            }
        }

        private void tbkLike_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var fb = new FacebookClient(_accessToken);
            try
            {
                if (fb.Post(post.id + "/likes") == true)
                {
                    new Warning("Like exitoso").ShowDialog();
                    return;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
