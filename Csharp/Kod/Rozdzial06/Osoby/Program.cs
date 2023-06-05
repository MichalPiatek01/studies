using static System.Console;
using System;
using CS7;

namespace Osoby
{
    class Program
    {
        static void Main()
        {
            var henryk = new Osoba { Nazwisko = "Henryk" };
            var maria = new Osoba { Nazwisko = "Maria" };
            var julia = new Osoba { Nazwisko = "Julia" };
            // wywołanie metody obiektu
            var dziecko1 = maria.ProkreacjaZ(henryk);
            // wywołanie metody statycznej
            var dziecko2 = Osoba.Prokreacja(henryk, julia);
            // wywołanie operatora
            var dziecko3 = henryk * maria;
            WriteLine($"{maria.Nazwisko} ma {maria.Dzieci.Count} dzieci.");
            WriteLine($"{henryk.Nazwisko} ma {henryk.Dzieci.Count} dzieci.");
            WriteLine($"{julia.Nazwisko} ma {julia.Dzieci.Count} dzieci.");
            WriteLine($" Pierwsze dziecko {maria.Nazwisko} nazywa się\"{maria.Dzieci[0].Nazwisko}\".");

            WriteLine($"5! to {Osoba.Silnia(5)}");

            henryk.Krzycz += Henryk_Krzycz;
            henryk.Szturchnij();
            henryk.Szturchnij();
            henryk.Szturchnij();
            henryk.Szturchnij();

            Osoba[] osoby =
            {
                new Osoba { Nazwisko = "Stasiak" },
                new Osoba { Nazwisko = "Janiak" },
                new Osoba { Nazwisko = "Adun" },
                new Osoba { Nazwisko = "Rykszak" }
            };
            
            WriteLine("Początkowa lista osób:");
            foreach (var osoba in osoby)
            {
                WriteLine($"{osoba.Nazwisko}");
            }
            
            WriteLine("Do posortowania użyto zaimplementowanego interfejsu IComparable:");
            Array.Sort(osoby);
            foreach (var osoba in osoby)
            {
                WriteLine($"{osoba.Nazwisko}");
            }

            WriteLine("Do posortowania użyto implementacji interfejsu IComparer w klasie OsobaComparer: ");
            Array.Sort(osoby, new OsobaComparer());
            foreach (var osoba in osoby)
            {
                WriteLine($"{osoba.Nazwisko}");
            }

            var r = new Rzecz();
            r.Dane = 42;
            WriteLine($"Rzecz: {r.Obsluga("42")}");
            var gr = new GenerycznaRzecz<int>();
            gr.Dane = 42;
            WriteLine($"GenerycznaRzecz: {gr.Obsluga("42")}");

            string liczba1 = "4";
            WriteLine($"{liczba1} do kwadratu to {DoKwadratu.Kwadrat<string>(liczba1)}");
            byte liczba2 = 3;
            WriteLine($"{liczba2} do kwadratu to {DoKwadratu.Kwadrat<byte>(liczba2)}");

            var wp1 = new WektorPrzesuniencia(3, 5);
            var wp2 = new WektorPrzesuniencia(-2, 7);
            var wp3 = wp1 + wp2;
            WriteLine($"({wp1.X}, {wp1.Y}) + ({wp2.X}, {wp2.Y}) = ({wp3.X}, {wp3.Y})");

            Pracownik p1 = new Pracownik
            {
                Nazwisko = "Jacek Jankowski",
                DataUrodzenia = new DateTime(1990, 7, 28)
            };
            p1.WypiszWKonsoli();

            p1.KodPracownika = "JJ001";
            p1.DataZatrudnienia = new DateTime(2014, 11, 23);
            WriteLine($"{p1.Nazwisko} został zatrudniony {p1.DataZatrudnienia:dd/MM/yy}");

            WriteLine(p1.ToString());

            Pracownik pracownikAlicja = new Pracownik
            {
                Nazwisko = "Alicja",
                KodPracownika = "AA123"
            };
            Osoba osobaAlicja = pracownikAlicja;
            pracownikAlicja.WypiszWKonsoli();
            osobaAlicja.WypiszWKonsoli();
            WriteLine(pracownikAlicja.ToString());
            WriteLine(osobaAlicja.ToString());

            // Pracownik p2 = (Pracownik)osobaAlicja;

            if (osobaAlicja is Pracownik)
            {
                WriteLine($"{nameof(osobaAlicja)} jest Pracownikiem");
                Pracownik p2 = (Pracownik)osobaAlicja;
                // zrób coś ze zmienną p2
            }

            Pracownik p3 = osobaAlicja as Pracownik;
            if (p3 != null)
            {
                WriteLine($"{nameof(osobaAlicja)} jako Pracownik");
                // zrób coś ze zmienną p3
            }

            try
            {
                p1.PodrozWCzasie(new DateTime(1999, 12, 31));
                p1.PodrozWCzasie(new DateTime(1950, 12, 25));
            }
            catch (WyjatekOsoba ex)
            {
                WriteLine(ex.Message);
            }

            string email1 = "pamela@test.com";
            string email2 = "jan&test.com";
            WriteLine($"{email1} to poprawny adres e-mail:{ RozszerzeniaDlaString.AdresPoprawny(email1)}.");
            WriteLine($"{email2} to poprawny adres e-mail:{ RozszerzeniaDlaString.AdresPoprawny(email2)}.");

            WriteLine($"{email1} to poprawny adres e-mail:{email1.AdresPoprawny()}.");
            WriteLine($"{email2} to poprawny adres e-mail:{email2.AdresPoprawny()}.");


        }

        private static void Henryk_Krzycz(object? sender, EventArgs e)
        {
            Osoba o = (Osoba)sender;
            WriteLine($"{o.Nazwisko} złości się na poziomie: {o.PoziomZlosci}.");
        }


    }
}
