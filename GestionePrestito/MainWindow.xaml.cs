using System;
using System.Collections.Generic;
using System.IO;
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
        string combo="";
        private void Calcola_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double nrate = double.Parse(txtrate.Text);
                double importo = double.Parse(txtimporto.Text);
                double tassoperc = double.Parse(txttasso.Text);
                double tasso = importo / 100 * tassoperc;
                double tot = tasso + importo;
                double rate = tot / nrate;
                combo = combocitta.Text;
                if (femmina.IsChecked == true)
                {
                    lblresult.Content += $"{txtcognome.Text} {txtnome.Text}, residente in {combo} nata il {data.SelectedDate.Value.ToShortDateString()}. Prestito di {txtimporto.Text} ad un tasso del {txttasso.Text} da restituire in {txtrate.Text} rate da {rate} euro ciascuna, per un totale di {tot}\n";
                }
                if (maschio.IsChecked == true)
                {
                    lblresult.Content += $"{txtcognome.Text} {txtnome.Text}, residente in {combo} nato il {data.SelectedDate.Value.ToShortDateString()}. Prestito di {txtimporto.Text} ad un tasso del {txttasso.Text} da restituire in {txtrate.Text} rate da {rate} euro ciascuna, per un totale di {tot}\n";
                }
                btnnuovo.IsEnabled = true;
                txtrestituire.Text=tot.ToString();
                txtimpxrata.Text = rate.ToString();

            }
            catch
            {
                throw new Exception("Inserire tutti i dati necessari");
            }
           
        }

        private void Nuovo_Click_1(object sender, RoutedEventArgs e)
        {
            txtcognome.Text = null;
            txtimporto.Text = null;
            txtnome.Text = null;
            txtrate.Text = null;
            txtrestituire.Text = null;
            txttasso.Text = null;
            txtimpxrata.Text = null;
            femmina.IsChecked = false;
            maschio.IsChecked = false;
            data.SelectedDate = null;
            combocitta.SelectedItem = null;
        }

        private void Btnstampa_Click(object sender, RoutedEventArgs e)
        {

            using (StreamWriter sw = new StreamWriter("file.csv", false, Encoding.UTF8))
            {
                sw.WriteLine("Cognome;Nome;Città;Sesso;Data di nascita;Importo richiesto (€);% di interesse; Numero di rate;Importo Rata (€);Totale € da restituire");
                if (femmina.IsChecked == true)
                {
                    sw.WriteLine($"{txtcognome.Text}; {txtnome.Text};{combo};F;{data.SelectedDate.Value.ToShortDateString()};{txtimporto.Text};{txttasso.Text};{txtrate.Text};{txtimpxrata.Text};{txtrestituire.Text}");
                }
                else
                {
                    sw.WriteLine($"{txtcognome.Text}; {txtnome.Text};{combo};M;{data.SelectedDate.Value.ToShortDateString()};{txtimporto.Text};{txttasso.Text};{txtrate.Text};{txtimpxrata.Text};{txtrestituire.Text}");
                }
                //Funzionante, fatto senza lista
            
            }
            
        }
    }
}
