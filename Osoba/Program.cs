
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osoba.Klasy;


namespace Osoba
{

    public enum Plcie
    {
        K,
        M
    }

    [Serializable()]
    class Program
    {
        static void Main(string[] args)
        {
            /*Person osoba1 = new Person("BeAta", "Nowak", "1992-10-22", "92102201347", Plcie.K, "10", "123456789");
            Person osoba2 = new Person("Jan", "JanoWski", "1993-03-15", "93031507772", Plcie.M, "15", "987654321");
            Person osoba3 = new Person("Marta", "Kurowska", "2005-04-19", "05241905569", Plcie.K, "12", "012378956");

            Console.WriteLine(DateTime.Now + "\n");

            Console.WriteLine(osoba1);
            Console.WriteLine(osoba2);
            Console.WriteLine(osoba3);*/

            /*CzlonekZespolu czlonek1 = new CzlonekZespolu("Beata", "Nowak", "1992-10-22", "92102213477", Plcie.K, "2020-01-01", "projektant");
            CzlonekZespolu czlonek2 = new CzlonekZespolu("Jan", "Janowski", "1992-03-15", "92031507772", Plcie.M, "2019-06-12", "programista");

            Console.WriteLine(czlonek1);
            Console.WriteLine(czlonek2);

            KierownikZespolu kierownik = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070100212", Plcie.M, 5);

            Console.WriteLine(kierownik);*/

            /*
            string nazwa1 = "Grupa IT";
            KierownikZespolu kierownik1 = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070142412", Plcie.M, 5);

            CzlonekZespolu czlonek1 = new CzlonekZespolu("Witold", "Adamski", "1992-10-22", "92102266738", Plcie.M, "2020-01-01", "sekretarz");
            CzlonekZespolu czlonek2 = new CzlonekZespolu("Jan", "Janowski", "1992-03-15", "92031507772", Plcie.M, "2019-06-12", "programista");
            CzlonekZespolu czlonek3 = new CzlonekZespolu("Jan", "But", "1992-05-16", "92051613915", Plcie.M, "2019-06-01", "programista");
            CzlonekZespolu czlonek4 = new CzlonekZespolu("Anna", "Mysza", "1991-07-22", "91072235964", Plcie.K, "2020-01-01", "projektant");
            CzlonekZespolu czlonek5 = new CzlonekZespolu("Beata", "Nowak", "1992-10-22", "92102213477", Plcie.K, "2020-01-01", "projektant");

            Zespol zespol1 = new Zespol(nazwa1, kierownik1);

            zespol1.DodajCzlonka(czlonek1);
            zespol1.DodajCzlonka(czlonek2);
            zespol1.DodajCzlonka(czlonek3);
            zespol1.DodajCzlonka(czlonek4);
            zespol1.DodajCzlonka(czlonek5);

            Console.WriteLine(zespol1);

            Console.WriteLine("\nCzlonkowie zatrudnieni w styczniu: ");
            zespol1.WyszukajCzlonkow(1);
            
            Console.WriteLine("\nProgramisci: ");
            zespol1.WyszukajCzlonkow("programista");

            zespol1.UsunCzlonka("92102266738");
            zespol1.UsunCzlonka("Beata", "Nowak");

            Console.WriteLine("\n" + zespol1);

            zespol1.UsunWszytskich();

            Console.WriteLine(zespol1);*/

            
            string nazwa1 = "Grupa IT";
            KierownikZespolu kierownik1 = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070142412", Plcie.M, 5);

            CzlonekZespolu czlonek1 = new CzlonekZespolu("Witold", "Adamski", "1992-10-22", "92102266738", Plcie.M, "2020-01-01", "sekretarz");
            CzlonekZespolu czlonek2 = new CzlonekZespolu("Jan", "Janowski", "1992-03-15", "92031532652", Plcie.M, "2019-06-12", "programista");
            CzlonekZespolu czlonek3 = new CzlonekZespolu("Jan", "But", "1992-05-16", "92051613915", Plcie.M, "2019-06-01", "programista");
            CzlonekZespolu czlonek4 = new CzlonekZespolu("Anna", "Mysza", "1991-07-22", "91072235964", Plcie.K, "2020-01-01", "projektant");
            CzlonekZespolu czlonek5 = new CzlonekZespolu("Beata", "Nowak", "1992-11-22", "93112225023", Plcie.K, "2020-01-01", "projektant");

            
            Zespol zespol1 = new Zespol(nazwa1, kierownik1);

            zespol1.DodajCzlonka(czlonek1);
            zespol1.DodajCzlonka(czlonek2);
            zespol1.DodajCzlonka(czlonek3);
            zespol1.DodajCzlonka(czlonek4);
            zespol1.DodajCzlonka(czlonek5);
            /*
            Console.WriteLine(zespol1 + "\n---------------------\n");

            Zespol zespol2 = (Zespol)zespol1.Clone();
            zespol2.SetNazwa("NowaGrupa");
            KierownikZespolu kierownik2 = new KierownikZespolu("Rafał", "Marzec", "1988-03-21", "88032112357", Plcie.M, 6);
            zespol2.SetKierownikZespolu(kierownik2);

            zespol2.SortujPoPESEL();
            Console.WriteLine(zespol2);*/


            //Zespol.ZapiszXML("GrupaIT.xml", zespol1);

            //Console.WriteLine(Zespol.OdczytajXML("Grupa IT.xml"));

            zespol1.ZapiszBin("PlikBin.bin");

            Zespol zespol2 = new Zespol();
            zespol2 = (Zespol)zespol2.OdczytajBin("PlikBin.bin");

            Console.WriteLine(zespol2);

            Console.ReadKey();
        }
    }
}
