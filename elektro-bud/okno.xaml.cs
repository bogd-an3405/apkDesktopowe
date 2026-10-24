using System.Collections.ObjectModel;

using System.Windows;

namespace elektrobud
{
    public partial class okno : Window
    {
        ObservableCollection<produkt> produkty = new ObservableCollection<produkt>();

        public okno()
        {
            InitializeComponent();
            dgprodukty.ItemsSource = produkty;
        }

        private void dodaj_klik(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnazwa.Text) ||
                string.IsNullOrWhiteSpace(txtkodEAN.Text) ||
                string.IsNullOrWhiteSpace(txtilosc.Text) ||
                string.IsNullOrWhiteSpace(txtkategoria.Text) ||
                string.IsNullOrWhiteSpace(txtsektor.Text) ||
                string.IsNullOrWhiteSpace(txtregal.Text) ||
                string.IsNullOrWhiteSpace(txtpolka.Text))
            {
                MessageBox.Show("wypelnij wszystkie pola");
                return;
            }

            string kodEAN = txtkodEAN.Text.Trim();
            

            int ilosc;
            if (!int.TryParse(txtilosc.Text, out ilosc) || ilosc < 0)
            {
                MessageBox.Show("ilosc musi byc nieujemna");
                return;
            }

            produkty.Add(new produkt
            {
                nazwa = txtnazwa.Text.Trim(),
                kodEAN = kodEAN,
                ilosc = ilosc,
                kategoria = txtkategoria.Text.Trim(),
                sektor = txtsektor.Text.Trim(),
                regal = txtregal.Text.Trim(),
                polka = txtpolka.Text.Trim()
            });

            txtnazwa.Clear();
            txtkodEAN.Clear();
            txtilosc.Clear();
            txtkategoria.Clear();
            txtsektor.Clear();
            txtregal.Clear();
            txtpolka.Clear();
        }
    }
}
