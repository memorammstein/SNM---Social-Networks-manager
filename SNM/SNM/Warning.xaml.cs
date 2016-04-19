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
    /// Lógica de interacción para Warning.xaml
    /// </summary>
    public partial class Warning : Window
    {
        public Warning(string advertencia)
        {
            InitializeComponent();
            tbkWarning.Text = advertencia;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void btnAceptarAdvertencia_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
