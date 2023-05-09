using static System.Console;
using System.IO;

namespace Myapp
{
    class Instructions
    {
        static void Main(string[] args)
        {
            // możesz napisać bez nawiasów klamrowych bo jest tylko jedna linijka kodu | nie zaleca się
            if (args.Length == 0)
            {

                WriteLine("Nie ma żadnych argumentów");
            }
            else
            {
                WriteLine("Mam przynajmniej jeden argument");
            }

            object o = 3;
            int j = 4;

            if (o is int i)
            {
                WriteLine($"{i} * {j} = {i * j}");
            }
            else
            {
                WriteLine("o nie ma typu int wię nie mogę wykonać mnożenia");
            }

        Etykieta:
            var liczba = (new Random()).Next(1, 7);
            WriteLine($"Wylosowana liczba to {liczba}");
            switch (liczba)
            { 
                case 1:
                    WriteLine("Jeden");
                    break;  //skacze na koniec instrukcji switch

                case 2:
                    WriteLine("Dwa");
                    goto case 1;

                case 3:
                case 4:
                    WriteLine("Trzy lub cztery");
                    goto case 1;
                case 5:
                    // uśpienie prograu na pól sekundy
                    System.Threading.Thread.Sleep(500);
                    goto Etykieta;
                default:
                    WriteLine("Domyślnie");
                    break;
                    // koniec instrukcji switch 
            }
            string sciezka = @"C:\Users\Murzy\Desktop\Csharp\tutorial\Kod\Rozdzial03";
            Stream s = File.Open(Path.Combine(sciezka, "plik.txt "), FileMode.OpenOrCreate);
            switch (s)
            { 
                case FileStream writebleFile when s.CanWrite:
                    WriteLine("Strumień prowadzi do pliku, do którego mogę pisać.");
                    break;
                case FileStream readOnlyFile:
                    WriteLine("Strumień prowadzi do pliku tylko do odczytu");
                    break;
                case MemoryStream ms:
                    WriteLine("Strumień prowadzi do adresu w pamięci.");
                    break;
                default: // zawsze sprawdzamy na koncu, niezaleznie od pozycji w kodzie
                    WriteLine("To strumień innego typu");
                    break;
                case null:
                    WriteLine("Strumień ma wartość null");
                    break;
            }
        }
    }
}