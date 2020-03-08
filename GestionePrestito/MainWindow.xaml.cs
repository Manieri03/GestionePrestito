using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionePrestito
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calcola_Click(object sender, RoutedEventArgs e)
        {
            double nrate = double.Parse(txtrate.Text);
            double importo = double.Parse(txtimporto.Text);
            double tasso = double.Parse(txttasso.Text);
            double impcontasso=importo/100*tasso ;
            double rate = impcontasso / nrate;
            string combo = combocitta.Text;
            if (femmina.IsChecked == true)
            {
                lblresult.Content += $"{txtcognome.Text} {txtnome.Text}, residente in {combo} nata il {data.SelectedDate.Value.ToShortDateString()}. Prestito di {txtimporto.Text} ad un tasso del {txttasso.Text} da restituire in {txtrate.Text} rate da {rate} euro ciascuna, per un totale di {impcontasso}";
            }
            if (maschio.IsChecked == true)
            {
                lblresult.Content+= $"{txtcognome.Text} {txtnome.Text}, residente in {combo} nato il {data.SelectedDate.Value.ToShortDateString()}. Prestito di {txtimporto.Text} ad un tasso del {txttasso.Text} da restituire in {txtrate.Text} rate da {rate} euro ciascuna, per un totale di {impcontasso}";
            }
            btnnuovo.IsEnabled = true;
        }

        private void Nuovo_Click_1(object sender, RoutedEventArgs e)
        {
            txtcognome.Text = null;
            txtimporto.Text = null;
            txtnome.Text = null;
            txtrate.Text = null;
            txtrestituire.Text = null;
            txttasso.Text = null;
            femmina.IsChecked = false ;
            maschio.IsChecked = false;
            data.SelectedDate = null;
            combocitta.SelectedItem = null;
        }
    }
}
