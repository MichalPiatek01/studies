using CS7;
using System;
using static System.Console;

namespace Osoby
{
    class Program
    {
        static void Main()
        {
            // WriteLine(o1.ToString());
            var o1 = new Osoba();
            {
                o1.Nazwisko = "Adam Nowak";
                o1.DataUrodzenia = new System.DateTime(1965, 12, 22);
                o1.UlubionyAntycznyCud = AntyczneCudaSwiata.PosagZeusaWOlimpii;
                o1.DoOdwiedzenia = AntyczneCudaSwiata.WiszaceOgrodyBabilonu | AntyczneCudaSwiata.MauzoleumWHalikarnasie;
                o1.Dzieci.Add(new Osoba { Nazwisko = "Alfred" });
                o1.Dzieci.Add(new Osoba { Nazwisko = "Zuza" });
                // o1.DoOdwiedzenia = (AntyczneCudaSwiata)18;
            };
            WriteLine($"Ulubiony cud {o1.Nazwisko} to {o1.UlubionyAntycznyCud}.");
            WriteLine($"{o1.Nazwisko} urodził się w {o1.DataUrodzenia:dddd, d MMMM yyyy}");
            WriteLine($"{o1.Nazwisko} chce odwiedzić {o1.DoOdwiedzenia}");
            WriteLine($"{o1.Nazwisko} ma {o1.Dzieci.Count} dzieci:");
            for (int dziecko = 0; dziecko < o1.Dzieci.Count; dziecko++)
            {
                WriteLine($" {o1.Dzieci[dziecko].Nazwisko}");
            }

            var o2 = new Osoba
            {
                Nazwisko = "Alicja Kowalska",
                DataUrodzenia = new DateTime(1998, 3, 17)
            };
            WriteLine($"{o2.Nazwisko} urodziła się {o2.DataUrodzenia:d MMM yy}");

            KontoBankowe.Oprocentowanie = 0.012M;
            var kb1 = new KontoBankowe();
            kb1.NazwaKonta = "Pani Jadzia";
            kb1.Saldo = 2400;
            WriteLine($"{kb1.NazwaKonta} zarobiła {kb1.Saldo * KontoBankowe.Oprocentowanie:C} w odsetkach.");
            var kb2 = new KontoBankowe();
            kb2.NazwaKonta = "Pan Hilary";
            kb2.Saldo = 98;
            WriteLine($"{kb2.NazwaKonta} zarobił {kb2.Saldo * KontoBankowe.Oprocentowanie:C} w odsetkach.");

            WriteLine($"{o1.Nazwisko} to {Osoba.Gatunek}");
            WriteLine($"{o1.Nazwisko} pochodzi z planety {o1.Planeta}");

            var o3 = new Osoba();
            WriteLine($"{o3.Nazwisko}, utworzono o godzinie {o3.Utworzono:hh:mm:ss} w dniu { o3.Utworzono:dddd, d MMMM yyyy}");

            var o4 = new Osoba("Artur");
            WriteLine($"{o4.Nazwisko} został utworzony o godzinie { o4.Utworzono:hh: mm: ss} w dniu { o4.Utworzono:dddd, d MMMM yyyy}");

            o1.WypiszWKonsoli();
            WriteLine(o1.PodajPochodzenie());

            Tuple<string, int> owoc4 = o1.WezOwoceCS4();
            WriteLine($"Mam tutaj {owoc4.Item1}, sztuk {owoc4.Item2}.");
            (string, int) owoc7 = o1.WezOwoceCS7();
            WriteLine($"{owoc7.Item1}, jest ich {owoc7.Item2}.");

            var nazwanyOwoc = o1.PobierzNazwaneOwoce();
            WriteLine($"Czy masz {nazwanyOwoc.Liczba} {nazwanyOwoc.Nazwa}?");

            var krotka1 = ("Mateusz", 4);
            WriteLine($"{krotka1.Item1} ma {krotka1.Item2} dzieci.");
            var krotka2 = (o1.Nazwisko, o1.Dzieci.Count);
            WriteLine($"{krotka2.Item1} ma {krotka2.Item2} dzieci.");

            var krotka3 = (o1.Nazwisko, o1.Dzieci.Count);
            WriteLine($"{krotka3.Nazwisko} ma {krotka3.Count} dzieci.");

            (string nazwaOwocu, int liczbaOwocow) = o1.WezOwoceCS7();
            WriteLine($"Po dekonstrukcji: {nazwaOwocu}, {liczbaOwocow}");

            WriteLine(o1.PowiedzCzesc());
            WriteLine(o1.PowiedzCzesc("Emilia"));

            WriteLine(o1.ParametryOpcjonalne());
            WriteLine(o1.ParametryOpcjonalne("Skacz!", 98.5));
            WriteLine(o1.ParametryOpcjonalne(liczba: 52.7, polecenie: "Kryj się!"));
            WriteLine(o1.ParametryOpcjonalne("Siadaj!", aktywne: false));

            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Przed: a = {a}, b = {b}, c = {c}");
            o1.PrzekazywanieParametrow(a, ref b, out c);
            WriteLine($"Po: a = {a}, b = {b}, c = {c}");

            // uproszczona składnia parametrów out z języka C# 7
            int d = 10;
            int e = 20;
            WriteLine($"Przed: d = {d}, e = {e}, f jeszcze nie istnieje!");
            o1.PrzekazywanieParametrow(d, ref e, out int f);
            WriteLine($"Po: d = {d}, e = {e}, f = {f}");

            var staszek = new Osoba
            {
                Nazwisko = "Stanisław",
                DataUrodzenia = new DateTime(1972, 1, 27)
            };
            WriteLine(staszek.Pochodzenie);
            WriteLine(staszek.Pozdrowienie);
            WriteLine(staszek.Wiek);

            staszek.UlubioneLody = "czekoladowe";
            WriteLine($"Stanisław najchętniej je lody {staszek.UlubioneLody}.");
            staszek.UlubionyKolorPodstawowy = "czerwony";
            WriteLine($"Stanisław najbardziej lubi kolor {staszek.UlubionyKolorPodstawowy}.");

            staszek.Dzieci.Add(new Osoba { Nazwisko = "Karol" });
            staszek.Dzieci.Add(new Osoba { Nazwisko = "Zosia" });
            WriteLine($"Pierwsze dziecko Stanisława to {staszek.Dzieci[0].Nazwisko}");
            WriteLine($"Drugie dziecko Stanisława to {staszek.Dzieci[1].Nazwisko}");
            WriteLine($"Pierwsze dziecko Stanisława to {staszek[0].Nazwisko}");
            WriteLine($"Drugie dziecko Stanisława to {staszek[1].Nazwisko}");
        }
    }
}
