using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoba.Klasy
{
    public interface IZapisywalna
    {
        void ZapiszBin(string nazwa);

        Object OdczytajBin(string nazwa);
    }
}
