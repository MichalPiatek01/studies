using System;
using static System.Console;
using System.Collections.Generic;

namespace CS7
{
    public partial class Osoba : System.Object
    {
        public Osoba(string wstepneNazwisko)
        {
            Nazwisko = wstepneNazwisko;
            Utworzono = DateTime.Now;
        }
        // pola
        public string Nazwisko;
        public DateTime DataUrodzenia;
        public AntyczneCudaSwiata UlubionyAntycznyCud;
        public AntyczneCudaSwiata DoOdwiedzenia;
        public List<Osoba> Dzieci = new List<Osoba>();
        
        // stałe
        public const string Gatunek = "Homo sapiens";

        // pola tylko do odczytu
        public readonly string Planeta = "Ziemia";
        public readonly DateTime Utworzono;

        // konstruktory
        public Osoba()
        {
            // ustalamy domyślne wartości pól, w tym pól do odczytu
            Nazwisko = "Nieznane";
            Utworzono = DateTime.Now;
        }

        // metody
        public void WypiszWKonsoli()
        {
            WriteLine($"{Nazwisko} urodził się w {DataUrodzenia:dddd, d MMMM yyyy}");
        }

        public string PodajPochodzenie()
        {
            return ($"{Nazwisko} pochodzi z planety {Planeta}");
        }

        // stary typ System.Tuple z C# 4 i .NET 4.0
        public Tuple<string, int> WezOwoceCS4()
        {
            return Tuple.Create("Jabłka", 5);
        }
        
        // nowy typ System.ValueTuple oraz składnia z C# 7
        public (string, int) WezOwoceCS7()
        {
            return ("Jabłka", 5);
        }

        public (string Nazwa, int Liczba) PobierzNazwaneOwoce()
        {
            return (Nazwa: "Jabłka", Liczba: 5);
        }

        public string PowiedzCzesc()
        {
            return $"{Nazwisko} mówi 'Cześć!'";
        }
        public string PowiedzCzesc(string imie)
        {
            return $"{Nazwisko} mówi 'Cześć, {imie}!'";
        }

        public string ParametryOpcjonalne(string polecenie = "Biegnij!", double liczba = 0.0, bool aktywne = true)
        {
            return $"polecenie to {polecenie}, liczba to {liczba}, aktywne to {aktywne}";
        }

        public void PrzekazywanieParametrow(int x, ref int y, out int z)
        {
            // parametry typu out nie mają wartości domyślnej
            // i muszą zostać zainicjowane wewnątrz metody
            z = 99;
            // zwiększenie wartości wszystkich parametrów
            x++;
            y++;
            z++;
        }

    }

}