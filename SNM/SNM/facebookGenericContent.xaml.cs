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

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para facebookGenericContent.xaml
    /// </summary>
    public partial class facebookGenericContent : UserControl
    {
        dynamic post;
        public facebookGenericContent(dynamic post)
        {
            this.post = post;
            InitializeComponent();
            if (post.ContainsKey("picture"))
            {
                contentImage.Source = new BitmapImage(new Uri(post.picture));
            }
            if (post.ContainsKey("name"))
            {
                tbkName.Text = post.name;
            }
            else
            {
                tbkName.Text = "";
            }
            if (post.ContainsKey("caption"))
            {
                tbkCaption.Text = post.caption;
            }
            else
            {
                tbkCaption.Text = "";
            }
            if (post.ContainsKey("description"))
            {
                tbkDescription.Text = post.description;
            }
            else
            {
                tbkDescription.Text = "";
            }
        }

        private void tbkName_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(post.link);
        }

        private void contentImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(post.link);
        }
    }
}
