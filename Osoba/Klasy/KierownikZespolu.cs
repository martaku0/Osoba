using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osoba.Klasy;

namespace Osoba.Klasy 
{
    [Serializable()]
    public class KierownikZespolu : Person, ICloneable
    {
        public int doswiadczenie;

        public int GetDoswiadczenie()
        {
            return doswiadczenie;
        }
        public void SetDoswiadczenie(int _doswiadczenie)
        {
            doswiadczenie = _doswiadczenie;
        }

        public KierownikZespolu() { }

        public KierownikZespolu(string _imie, string _nazwisko, string _data_urodzenia, string _pesel, Plcie _plec, int _doswiadczenie) : base(_imie, _nazwisko, _data_urodzenia, _pesel, _plec)
        {
            doswiadczenie = _doswiadczenie;
        }

        public override string ToString()
        {
            Format(GetImie(), GetNazwisko());
            return GetImie() + " " + GetNazwisko() + ", " + GetPesel() + " " + GetDataUrodzenia().ToString("dd-MM-yyyy");
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
