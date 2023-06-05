using System;
using static System.Console;

namespace CS7
{
    public class Pracownik : Osoba
    {
        public string KodPracownika { get; set; }
        public DateTime DataZatrudnienia { get; set; }

        public new void WypiszWKonsoli()
        {
            WriteLine($"{Nazwisko}, data urodzenia {DataUrodzenia:dd/MM/yy}, data zatrudnienia {DataZatrudnienia:dd/MM/yy}");
        }

        public override string ToString()
        {
            return $"Kod pracownika {Nazwisko} to {KodPracownika}";
        }
    }
}
