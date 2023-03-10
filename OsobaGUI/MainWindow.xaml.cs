using Osoba.Klasy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OsobaGUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {

        Zespol zespol = new Zespol();
        Zespol zespol_podst = new Zespol();

        private bool isChanged()
        {
            zespol.nazwa = nazwaTxtB.Text;
            if (zespol.nazwa != zespol_podst.nazwa || zespol.kierownik.ToString() != zespol_podst.kierownik.ToString())
            {
                return true;
            }
            else if(zespol.nazwa == zespol_podst.nazwa && zespol.kierownik.ToString() == zespol_podst.kierownik.ToString())
            {
                foreach (CzlonekZespolu cz in zespol.czlonkowie)
                {
                    foreach (CzlonekZespolu cz2 in zespol_podst.czlonkowie)
                    {
                        if (cz == cz2)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private void Zapisz()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                zespol.nazwa = nazwaTxtB.Text;
                Zespol.ZapiszXML(filename, zespol);
            }
        }

        private void Otworz(string _filename)
        {
            zespol = (Zespol)Zespol.OdczytajXML(_filename);
            zespol_podst = (Zespol)Zespol.OdczytajXML(_filename);
            zespol.Sortuj();
            czlonkowieListB.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
            nazwaTxtB.Text = zespol.nazwa;
            kierownikTxtB.Text = zespol.kierownik.ToString();
        }

        public MainWindow()
        {

            InitializeComponent();
            Otworz("GrupaIT.xml");
        }


        private void czlonkowieListB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void nazwaTxtB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void kierownikTxtB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void zmienBttn_Click(object sender, RoutedEventArgs e)
        {
            OsobaWindow okno = new OsobaWindow(zespol.kierownik);
            okno.ShowDialog();
            kierownikTxtB.Text = zespol.kierownik.ToString();
        }

        private void dodajBttn_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OsobaWindow okno = new OsobaWindow(cz);
            okno.ShowDialog();
            zespol.DodajCzlonka(cz);
            czlonkowieListB.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
        }

        private void usunBttn_Click(object sender, RoutedEventArgs e)
        {
            if (czlonkowieListB.SelectedIndex == -1)
            {
                MessageBox.Show("Zaznacz osobę.", "Error", MessageBoxButton.OK);
            }
            else
            {
                int zaznaczony = czlonkowieListB.SelectedIndex;
                zespol.czlonkowie.RemoveAt(zaznaczony);
                czlonkowieListB.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
            }
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Zapisz();
        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                string filename = dlg.FileName;
                Otworz(filename);
            }
        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            if(this.isChanged())
            {
                MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać niezapisane zmiany?", "Zapis", MessageBoxButton.YesNoCancel);
                if(result == MessageBoxResult.Yes)
                {
                    Zapisz();
                    Close();
                }
                else if(result == MessageBoxResult.No)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void zmienCzlonkaBttn_Click(object sender, RoutedEventArgs e)
        {
            if(czlonkowieListB.SelectedIndex == -1)
            {
                MessageBox.Show("Zaznacz osobę.", "Error", MessageBoxButton.OK);
            }
            else
            {
                int zaznaczony = czlonkowieListB.SelectedIndex;
                OsobaWindow okno = new OsobaWindow(zespol.czlonkowie.ElementAt(zaznaczony));
                okno.ShowDialog();
                czlonkowieListB.SelectedItem = zespol.czlonkowie.ElementAt(zaznaczony);
            }
            
        }
    }
}
