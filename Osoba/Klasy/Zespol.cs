using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Osoba.Klasy
{
    [Serializable()]
    public class Zespol : ICloneable, IZapisywalna
    {
        public int liczbaCzlonkow = 0;
        public string nazwa = null;
        public KierownikZespolu kierownik = null;
        public List<CzlonekZespolu> czlonkowie  = new List<CzlonekZespolu>();

        public Zespol()
        {
            liczbaCzlonkow = 0;
            nazwa = null;
            kierownik = null;
            czlonkowie = new List<CzlonekZespolu>();
        }

        public Zespol(string _nazwa, KierownikZespolu _kierownik)
        {
            nazwa = _nazwa;
            kierownik = _kierownik;
        }

        public int GetLiczbaCzlonkow()
        {
            return liczbaCzlonkow;
        }
        public void SetLiczbaCzlonkow(int _liczbaCzlonkow)
        {
            liczbaCzlonkow = _liczbaCzlonkow;
        }
        public string GetNazwa()
        {
            return nazwa;
        }
        public void SetNazwa( string _nazwa)
        {
            nazwa = _nazwa;
        }
        public void SetPesel(string _nazwa)
        {
            nazwa = _nazwa;
        }
        public KierownikZespolu GetKierownikZespolu()
        {
            return kierownik;
        }
        public void SetKierownikZespolu(KierownikZespolu _kierownik)
        {
            kierownik = _kierownik;
        }

        public void DodajCzlonka(CzlonekZespolu _czlonek)
        {
            
            if(_czlonek.pesel != "00000000000")
            {
                czlonkowie.Add(_czlonek);
                liczbaCzlonkow += 1;
            }
        }

        public override string ToString()
        {
            Console.WriteLine("Zespół "+GetNazwa()+"\n\nKierownik:\n"+GetKierownikZespolu()+"\nCzłonkowie:\n");
            foreach(CzlonekZespolu _czlonek in czlonkowie)
            {
                Console.Write(_czlonek +"\n");
            }
            return "";
        }

        
        private bool JestCzlonkiem(string _pesel)
        {   
            foreach(CzlonekZespolu _czlonek in czlonkowie)
            {
                if(_czlonek.GetPesel() == _pesel)
                {
                    return true;
                }
            }
            return false;
        }

        private bool JestCzlonkiem(string _imie, string _nazwisko)
        {
            foreach (CzlonekZespolu _czlonek in czlonkowie)
            {
                if (_czlonek.GetImie() == _imie && _czlonek.GetNazwisko() == _nazwisko)
                {
                    return true;
                }
            }
            return false;
        }

        public void UsunCzlonka(string _pesel)
        {
            if(JestCzlonkiem(_pesel))
            {
                foreach (CzlonekZespolu _czlonek in czlonkowie)
                {
                    if (_czlonek.GetPesel() == _pesel)
                    {
                        czlonkowie.Remove(_czlonek);
                        liczbaCzlonkow -= 1;
                        break;
                    }
                }
            }
            
        }

        public void UsunCzlonka(string _imie, string _nazwisko)
        {
            if(JestCzlonkiem(_imie, _nazwisko))
            {
                foreach (CzlonekZespolu _czlonek in czlonkowie)
                {
                    if (_czlonek.GetImie() == _imie && _czlonek.GetNazwisko() == _nazwisko)
                    {
                        czlonkowie.Remove(_czlonek);
                        liczbaCzlonkow -= 1;
                        break;
                    }
                }
            }
            
        }

        public void UsunWszytskich()
        {
            czlonkowie.Clear();
            liczbaCzlonkow = 0;
        }

        public void WyszukajCzlonkow(string _funkcja)
        {
            List<CzlonekZespolu> lista = new List<CzlonekZespolu>();

            foreach (CzlonekZespolu _czlonek in czlonkowie)
            {
                if (_czlonek.GetFunkcja() == _funkcja)
                {
                    lista.Add(_czlonek);
                }
            }

            int i = 1;
            foreach (CzlonekZespolu _czlonek in lista)
            {
                Console.WriteLine(i + ". " + _czlonek);
                i++;
            }
        }

        public void WyszukajCzlonkow(int _miesiac)
        {
            List<CzlonekZespolu> lista = new List<CzlonekZespolu>();

            foreach (CzlonekZespolu _czlonek in czlonkowie)
            {
                if (_czlonek.GetDataZapisu().Month == _miesiac)
                {
                    lista.Add(_czlonek);
                }
            }

            int i = 1;
            foreach (CzlonekZespolu _czlonek in lista)
            {
                Console.WriteLine(i + ". " +_czlonek);
                i++;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public class PESELComparator : IComparer<CzlonekZespolu>
        {
            public int Compare(CzlonekZespolu c1, CzlonekZespolu c2)
            {
                int compareDate = c1.GetPesel().CompareTo(c2.GetPesel());
                if (compareDate == 0)
                {
                    return c2.GetPesel().CompareTo(c1.GetPesel());
                }
                return compareDate;
            }
        }

        public void Sortuj()
        {
            czlonkowie.Sort();
        }

        public void SortujPoPESEL()
        {
            czlonkowie.Sort(new PESELComparator());
        }

        public bool JestCzlonkiem(Person _p1)
        {
            foreach (CzlonekZespolu _czlonek in czlonkowie)
            {
                if(Equals(_p1, _czlonek))
                {
                    return true;
                }
            }

            return false;
        }

        public static void ZapiszXML(string _nazwa, Zespol _z)
        {
            using ( var stream = new FileStream(_nazwa, FileMode.Create))
            {
                var XML = new XmlSerializer(typeof(Zespol));
                XML.Serialize(stream, _z);
            }
        }

        public static Zespol OdczytajXML(string _nazwa)
        {
            var serialize = new XmlSerializer(typeof(Zespol));

            Zespol z = null;

            using (var stream = new StreamReader(_nazwa))
            {
                z = (Zespol)serialize.Deserialize(stream);
            }

            return z;
        }

        
        public void ZapiszBin(string nazwa)
        {
            BinaryFormatter format = new BinaryFormatter();
            if (File.Exists(nazwa))
            {
                File.Delete(nazwa);
            }
            FileStream fs = new FileStream(nazwa, FileMode.Create);
            try
            {
                format.Serialize(fs, Clone());

                Console.WriteLine("Serializacja udana");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Blad serializacji: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        
        public object OdczytajBin(string _nazwa)
        {
            object z;
            FileStream fs = new FileStream(_nazwa, FileMode.Open);
            try 
            {
                BinaryFormatter formatter = new BinaryFormatter();
                z = formatter.Deserialize(fs);
            }
            catch (SerializationException e) 
            {
                Console.WriteLine("Blad deserializacji: " + e.Message);
                return 0;
            }
            finally 
            {
                fs.Close();
            }
            return z;
        }
    }
}
