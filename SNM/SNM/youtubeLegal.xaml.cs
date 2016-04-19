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

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para youtubeLegal.xaml
    /// </summary>
    public partial class youtubeLegal : Window
    {
        private bool accept = false;
        public bool Accept { get { return accept; } }
        public youtubeLegal()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            accept = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            accept = false;
            this.Close();
        }
    }
}
