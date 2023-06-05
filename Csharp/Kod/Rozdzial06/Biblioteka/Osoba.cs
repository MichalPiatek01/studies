using System;
using System.Collections.Generic;
using static System.Console;
namespace CS7
{
    public partial class Osoba : IComparable<Osoba>
    {
        // pola
        public string Nazwisko;
        public DateTime DataUrodzenia;
        public List<Osoba> Dzieci = new List<Osoba>();
        // metody
        public void WypiszWKonsoli()
        {
            WriteLine($"{Nazwisko}, data urodzenia {DataUrodzenia:dddd, d MMMM yyyy}");
        }

        // metody "rozmnażania"
        public static Osoba Prokreacja(Osoba o1, Osoba o2)
        {
            var dziecko = new Osoba
            {
                Nazwisko = $"Dziecko osób {o1.Nazwisko} i {o2.Nazwisko}"
            };
            o1.Dzieci.Add(dziecko);
            o2.Dzieci.Add(dziecko);
            return dziecko;
        }
        public Osoba ProkreacjaZ(Osoba partner)
        {
            return Prokreacja(this, partner);
        }

        // operator "mnożenia"
        public static Osoba operator *(Osoba o1, Osoba o2)
        {
            return Osoba.Prokreacja(o1, o2);
        }

        // metoda z funkcją lokalną
        public static int Silnia(int liczba)
        {
            if (liczba < 0)
            {
                throw new ArgumentException($"{nameof(liczba)} nie może być mniejsza od zera.");
            }
            return lokalnaSilnia(liczba);
            int lokalnaSilnia(int lokalnaLiczba)
            {
                if (lokalnaLiczba < 1) return 1;
                return lokalnaLiczba * lokalnaSilnia(lokalnaLiczba - 1);
            }
        }

        // zdarzenie
        public event EventHandler Krzycz;
        // pole
        public int PoziomZlosci;
        // metoda
        public void Szturchnij()
        {
            PoziomZlosci++;
            if (PoziomZlosci >= 3)
            {
                // jeżeli coś słucha zdarzenia…
                if (Krzycz != null)
                {
                    // …to wywołaj zdarzenie
                    Krzycz(this, EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Osoba other)
        {
            return Nazwisko.CompareTo(other.Nazwisko);
        }

        public override string ToString()
        {
            return $"{Nazwisko} to {base.ToString()}";
        }

        public void PodrozWCzasie(DateTime kiedy)
        {
            if (kiedy <= DataUrodzenia)
            {
                throw new WyjatekOsoba("Jeżeli przeniesiesz się w czasie do daty wcześniejszej niż Twoja data urodzenia, to cały wszechświat eksploduje!");
            }
            else
            {
                WriteLine($"Witam w roku {kiedy:yyyy}!");
            }
        }
    }
    
}