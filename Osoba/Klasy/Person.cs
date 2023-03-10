using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoba.Klasy
{

    [Serializable()]
    public abstract class Person : IEquatable<Person>
    {
        public string imie;
        public string nazwisko;
        public DateTime dataUrodzenia;
        public string pesel;
        public Plcie plec;
        public string godzina;
        public string tel;

        public string GetImie()
        {
            return imie;
        }
        public void SetImie(string _imie)
        {
            imie = _imie;
        }

        public string GetNazwisko()
        {
            return nazwisko;
        }
        public void SetNazwisko(string _nazwisko)
        {
            nazwisko = _nazwisko;
        }

        public DateTime GetDataUrodzenia()
        {
            return dataUrodzenia;
        }
        public void SetDataUrodzenia(DateTime _dataUrodzenia)
        {
            dataUrodzenia = _dataUrodzenia;
        }

        public string GetPesel()
        {
            return pesel;
        }
        public void SetPesel(string _pesel)
        {
            pesel = _pesel;
        }

        public string GetTel()
        {
            return tel;
        }
        public void SetTel(string _tel)
        {
            tel = _tel;
        }

        public string GetGodzina()
        {
            return godzina;
        }
        public void SetGodzina(string _godzina)
        {
            godzina = _godzina;
        }
        public void SetPlec(Plcie _plec)
        {
            plec = _plec;
        }
        public Plcie GetPlec()
        {
            return plec;
        }

        public Person()
        {
            imie = "Imie";
            nazwisko = "Nazwisko";
            dataUrodzenia = DateTime.Now;
            pesel = "00000000000";
            plec = Plcie.M;
            godzina = "0";
            tel = "000000000";
        }

        public Person(string _imie, string _nazwisko)
        {
            imie = _imie;
            nazwisko = _nazwisko;
        }

        public Person(string _imie, string _nazwisko, string _data_urodzenia, string _pesel, Plcie _plec)
        {
            imie = _imie;
            nazwisko = _nazwisko;
            DateTime.TryParseExact(_data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yyyy", "dd-MM-yyyy" }, null, DateTimeStyles.None, out dataUrodzenia);
            pesel = _pesel;
            plec = _plec;
        }

        public Person(string _imie, string _nazwisko, string _data_urodzenia, string _pesel, Plcie _plec, string _godzina, string _tel)
        {
            imie = _imie;
            nazwisko = _nazwisko;
            DateTime.TryParseExact(_data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yyyy", "dd-MM-yyyy" }, null, DateTimeStyles.None, out dataUrodzenia);
            pesel = _pesel;
            plec = _plec;
            godzina = _godzina;
            tel = _tel;
        }

        public int Wiek()
        {
            int wiek;

            wiek = DateTime.Now.Year - dataUrodzenia.Year -1;

            if(DateTime.Now.Month > dataUrodzenia.Month)
            {
                wiek += 1;
            }
            else if(DateTime.Now.Month == dataUrodzenia.Month)
            {
                if(DateTime.Now.Day >= dataUrodzenia.Day)
                {
                    wiek += 1;
                }
            } 

            return wiek;
        }

        public void Format(string _imie, string _nazwisko)
        {
            _imie = _imie.Remove(0, 1).ToLower();
            _nazwisko = _nazwisko.Remove(0, 1).ToLower();
            imie = imie.Substring(0, 1).ToUpper();
            nazwisko = nazwisko.Substring(0, 1).ToUpper();
            imie += _imie;
            nazwisko += _nazwisko;
        }

        public double IleGodzin()
        {
            TimeSpan t = DateTime.Now - dataUrodzenia;
            double godziny = Math.Round(t.TotalHours, 0);
            godziny += 24-double.Parse(godzina);
            return godziny;
        }

        public bool CzyPoprawnyPesel()
        {
            if (pesel.Length == 11 && pesel.All(Char.IsDigit))
            {
                string rok = dataUrodzenia.Year.ToString();
                string miesiac = dataUrodzenia.Month.ToString();
                if(int.Parse(miesiac) < 10)
                {
                    string temp = miesiac;
                    miesiac = "0";
                    miesiac += temp;
                }
                string dzien = dataUrodzenia.Day.ToString();
                if (int.Parse(dzien) < 10)
                {
                    string temp = dzien;
                    dzien = "0";
                    dzien += temp;
                }

                if (rok[3] == pesel[1] && rok[2] == pesel[0])
                {
                    if (int.Parse(rok) < 2000)
                    {
                        if (miesiac[1] == pesel[3] && miesiac[0] == pesel[2])
                        {
                            if (dzien[1] == pesel[5] && dzien[0] == pesel[4])
                            {
                                int p = int.Parse(pesel.Substring(pesel.Length - 1));
                                if (plec == Plcie.K && p % 2 != 0)
                                {
                                    return true;
                                }
                                else if (plec == Plcie.M && p % 2 == 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        int temp = int.Parse(miesiac[0].ToString()) + 2;
                        int temp2 = int.Parse(pesel[2].ToString());
                        if (miesiac[1] == pesel[3] && temp == temp2)
                        {
                            if (dzien[1] == pesel[5] && dzien[0] == pesel[4])
                            {
                                int p = int.Parse(pesel[10].ToString());
                                if (plec == Plcie.K && p % 2 != 0)
                                {
                                    return true;
                                }
                                else if (plec == Plcie.M && p % 2 == 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override string ToString() 
        {
            Format(GetImie(), GetNazwisko());
            if(CzyPoprawnyPesel())
            {
                 return GetPesel() + " " + GetImie() + " " + GetNazwisko() + " (" + Wiek() + ") " + " Tel. " + GetTel() + "\nTa osoba przeżyła " + IleGodzin() + " godzin.\n";
            }
            else
            {
                return GetPesel() + " " + GetImie() + " " + GetNazwisko() + " (" + Wiek() + ") " + " Tel. " + GetTel() + "\nTa osoba przeżyła " + IleGodzin() + " godzin.\n" + "Pesel " + GetPesel() + " nie jest poprawny.\n";
            }
        }

        public bool Equals(Person p)
        {
            if (this.GetPesel() == p.GetPesel())
            {
                return true;
            }
            return false;
        }
    }
}
