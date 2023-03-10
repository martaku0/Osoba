using Osoba.Klasy;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace OsobaGUI
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWindow.xaml
    /// </summary>
    public partial class OsobaWindow : Window
    {
        Person _osoba;
        

        public OsobaWindow()
        {
            InitializeComponent();
        }

        public OsobaWindow(Person osoba):this()
        {
            _osoba = osoba;
            if(_osoba is KierownikZespolu)
            {
                peselTxtB.Text = _osoba.pesel;
                imieTxtB.Text = _osoba.imie;
                nazwiskoTxtB.Text = _osoba.nazwisko;
                dataTxtB.Text = _osoba.dataUrodzenia.ToString("dd-MM-yyyy");
                plecComboB.Text = ((_osoba.plec) == Osoba.Plcie.K) ? "Kobieta" : "Mężczyzna";
                funkcjaTxtB.Visibility = Visibility.Hidden;
                funkcjaLbl.Visibility = Visibility.Hidden;
            }
            else if(_osoba is CzlonekZespolu)
            {
                peselTxtB.Text = _osoba.pesel;
                imieTxtB.Text = _osoba.imie;
                nazwiskoTxtB.Text = _osoba.nazwisko;
                dataTxtB.Text = _osoba.dataUrodzenia.ToString("dd-MM-yyyy");
                plecComboB.Text = ((_osoba.plec) == Osoba.Plcie.K) ? "Kobieta" : "Mężczyzna";
                CzlonekZespolu cz_osoba = (CzlonekZespolu)_osoba;
                funkcjaTxtB.Text = cz_osoba.funkcja;
                
            }
        }

        private void zatwierdzBttn_Click(object sender, RoutedEventArgs e)
        {
            if(peselTxtB.Text != "" && imieTxtB.Text != "" && nazwiskoTxtB.Text != "" && plecComboB.Text != "")
            {
                _osoba.pesel = peselTxtB.Text;
                _osoba.imie = imieTxtB.Text;
                _osoba.nazwisko = nazwiskoTxtB.Text;
                string[] fdate = { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yyyy", "dd-MM-yyyy" };
                DateTime.TryParseExact(dataTxtB.Text, fdate, null, DateTimeStyles.None, out DateTime date);
                _osoba.dataUrodzenia = date;
                _osoba.plec = (plecComboB.Text == "Kobieta") ? Osoba.Plcie.K : Osoba.Plcie.M;
            }
            
            if(_osoba.dataUrodzenia.ToString("dd-MM-yyyy") == "01-01-0001")
            {
                MessageBox.Show("Nieprawidłowa data.", "Error", MessageBoxButton.OK);
            }
            else
            {
                DialogResult = true;
            }
        }

        private void anulujBttn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
