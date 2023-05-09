using System.ComponentModel;
using static System.Console;
using static System.Convert;

namespace RzutowanieKonwersji
{
    class Konwersatory
    {
        static void Main(string[] args)
        {
            int a = 10;
            double b = a; // liczbę typu int mozna zapisac w zmiennej typu double
            WriteLine(b);

            //Nie można natomiast niejawnie rzutować liczby typu double na typ int, ponieważ jest to operacja niebezpieczna, która może doprowadzić do utraty danych.
            //double c = 9.8;
            //int d = c; // zgłosi bład w tym wierszu
            //WriteLine(d);

            double c = 9.8;
            int d = (int)c;
            WriteLine(d);

            long e = 10;
            int f = (int)e;
            WriteLine($"e ma wartość {e}, a f ma wartość {f}");
            e = long.MaxValue;
            f = (int)e;
            WriteLine($"e ma wartość {e}, a f ma wartość {f}");

            double g = 9.8;
            int h = ToInt32(g);
            WriteLine($"g ma wartość {g}, a h ma wartość {h}");

            double i = 9.49;
            double j = 9.5;
            double k = 10.49;
            double l = 10.5;
            WriteLine($"i ma wartość {i}, a ToInt(i) ma wartość {ToInt32(i)}");
            WriteLine($"j ma wartość {j}, a ToInt(j) ma wartość {ToInt32(j)}");
            WriteLine($"k ma wartość {k}, a ToInt(k) ma wartość {ToInt32(k)}");
            WriteLine($"l ma wartość {l}, a ToInt(l) ma wartość {ToInt32(l)}");

            int number = 12;
            WriteLine(number.ToString());
            bool boolean = true;
            WriteLine(boolean.ToString());
            DateTime now = DateTime.Now;
            WriteLine(now.ToString());
            object me = new object();
            WriteLine(me.ToString());

            // przygotowanie tablicy 128 bajtów
            byte[] obiektBinarny = new byte[128];

            // wypełnienie tablicy losowymi bajtami
            (new Random()).NextBytes(obiektBinarny);

            WriteLine("Binarny obiekt jako bajty:");
            for (int indeks = 0; indeks < obiektBinarny.Length; indeks++)
            {
                Write($"{obiektBinarny[indeks]:X}");
            }
            WriteLine();

            //konwersja na ciąg znaków Base 64
            string zakodowane = Convert.ToBase64String(obiektBinarny);

            WriteLine($"Obiekt binarny jako Base64: {zakodowane}");

            int wiek = int.Parse("21");
            DateTime urodziny = DateTime.Parse("25/10/2001");
            WriteLine($"Mam {wiek} lat.");
            WriteLine($"Urodziny mam {urodziny}.");
            WriteLine($"Urodziny mam {urodziny:D}.");

            //int liczba = int.Parse("abc"); // System.FormatException: „Input string was not in a correct format.”

            WriteLine("Ile mamy tutaj jajek? ");
            int liczba;
            string dane = ReadLine();
            if (int.TryParse(dane, out liczba))
            {
                WriteLine($"Mamy {liczba} jajek.");
            }
            else
            {
                WriteLine("Konwersja danych wejściowych nie powiodła się");
            }

        }
    }
}