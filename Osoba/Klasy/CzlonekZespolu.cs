using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoba.Klasy
{
    [Serializable()]
    public class CzlonekZespolu : Person, ICloneable, IComparable<CzlonekZespolu>
    {
        public DateTime dataZapisu;
        public string funkcja;

        public DateTime GetDataZapisu()
        {
            return dataZapisu;
        }
        public void SetDataZapisu(DateTime _dataZapisu)
        {
            dataZapisu = _dataZapisu;
        }

        public string GetFunkcja()
        {
            return funkcja;
        }

        public void SetFunkcja(string _funkcja)
        {
            funkcja = _funkcja;
        }

        public CzlonekZespolu() { }

        public CzlonekZespolu(string _imie, string _nazwisko, string _data_urodzenia, string _pesel, Plcie _plec, string _dataZapisu, string _funkcja) : base(_imie, _nazwisko, _data_urodzenia, _pesel, _plec)
        {
            funkcja = _funkcja;
            DateTime.TryParseExact(_dataZapisu, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out dataZapisu);
        }

        public override string ToString()
        {
            Format(GetImie(), GetNazwisko());
            return GetImie() + " " + GetNazwisko() + ", " + GetPesel() + " " + GetDataUrodzenia().ToString("dd-MM-yyyy") + " " + GetFunkcja();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(CzlonekZespolu _c)
        {
            if (this.GetNazwisko() != _c.GetNazwisko())
            {
                int compareDate = this.GetNazwisko().CompareTo(_c.GetNazwisko());
                if (compareDate == 0)
                {
                    return _c.GetNazwisko().CompareTo(this.GetNazwisko());
                }
                return compareDate;
            }
            else
            {
                int compareDate = this.GetImie().CompareTo(_c.GetImie());
                if (compareDate == 0)
                {
                    return _c.GetImie().CompareTo(this.GetImie());
                }
                return compareDate;
            }
        }
    }
}
