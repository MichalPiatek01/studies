//using system.xml.serialization;

//var fullname = firstname + lastname;

//var cena = koszt + podatek; // podatek wynosi 20% kosztu

/*
 * komentarz 
 * wielowierszowy
 * */

using System; // średnik oznacza zakończenie instrukcji

namespace Podstawy
{
    class Program
    {
        static void Main(string[] args)
        { // początek bloku
            Console.WriteLine("Witaj świecie!"); // instrukcja
        } // koniec bloku
    }
}

// niech zmienna wysokoscWMetrach otrzyma wartość 1,88
// double wysokoscWMetrach = 1.88;
// Console.WriteLine($"Zmienna {nameof(wysokoscWMetrach)} ma wartość
// { wysokoscWMetrach}.");

// char litera = 'A';
// char cyfra = '1';
// char symbol = '$';
// char odUzytkownika = PobierzZnakOdUzytkownika();

// string imie = "Piotr";
// string nazwisko = "Kowalski";
// string numerTelefonu = "(215) 555-4256";
// string adres = PobierzAdresZBazyDanych(id: 563);

// uint liczbaCalkowita = 23; // liczba całkowita bez znaku może być wyłącznie dodatnia
// int liczbaCalkowitaZeZnakiem = -23; // liczba całkowita ze znakiem może być dodatnia i ujemna
// double liczbaRzeczywista = 2.3; // double oznacza liczbę zmiennoprzecinkową o podwójnej precyzji

// int notacjaDziesietna = 2_000_000; // 2 miliony
// int notacjaBinarna = 0b0001_1110_1000_0100_1000_0000; // 2 miliony
// int notacjaSzesnastkowa = 0x001E_8480; // 2 miliony
// Console.WriteLine($"{notacjaDziesietna == notacjaBinarna}"); // => true
// Console.WriteLine($"{notacjaDziesietna == notacjaSzesnastkowa}"); // => true
