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

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para facebookComment.xaml
    /// </summary>
    public partial class facebookComment : UserControl
    {
        public facebookComment(dynamic comment)
        {
            InitializeComponent();

            string pictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}", comment.from.id, "square");
            commentAvatarImage.Source = new BitmapImage(new Uri(pictureUrl));

            tbkCommentUserName.Text = comment.from.name;

            tbkCommentMessage.Text = comment.message;

            string date = comment.created_time;
            char[] separadores = { '-', 'T', '+', ':' };
            string[] partesDeFecha = date.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            int año = Convert.ToInt32(partesDeFecha[0]);
            int mes = Convert.ToInt32(partesDeFecha[1]);
            int dia = Convert.ToInt32(partesDeFecha[2]);
            int hora = Convert.ToInt32(partesDeFecha[3]);
            int minuto = Convert.ToInt32(partesDeFecha[4]);
            int segundo = Convert.ToInt32(partesDeFecha[5]);
            var postDate = new DateTime(año, mes, dia, hora, minuto, segundo, DateTimeKind.Utc);
            postDate = postDate.ToLocalTime();
            string fixedDate = postDate.ToLongDateString() + "   " + postDate.ToLongTimeString();
            tbkCommentDate.Text = fixedDate;
        }
    }
}
