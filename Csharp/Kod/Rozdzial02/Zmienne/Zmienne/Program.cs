using static System.Console;
using System.Xml;

namespace Myapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object wysokosc = 1.88; // zapisanie wartości typu double w zmiennej typu object
            // object imie = "Piotr"; // zapisanie wartości typu string w zmiennej typu object
            // int dlugosc1 = imie.Length; // powoduje błąd kompilacji!
            // int dlugosc2 = ((string)imie).Length; // rzutowanie daje dostęp do elementów obiektu

            // przechowywanie wartości typu string w zmiennej typu dynamic
            dynamic inneImie = "Paweł";
            // tę instrukcję można skompilować, ale może ona powodować błędy w czasie pracy programu!
            int dlugosc = inneImie.Length;

            // int populacja = 38_000_000; // 38 mln ludzi w Polsce
            // double waga = 1.88; // w kilogramach
            // decimal cena = 4.99M; // w złotówkach
            // string owoce = "jabłka"; // ciąg znaków w cudzysłowie
            // char litera = 'Z'; // znaki umieszczamy między apostrofami
            // bool radosc = true; // typ bool przyjmuje wartości true lub false

            // staraj sie nie robic var
            var populacja = 38_000_000; // 38 mln ludzi w Polsce
            var waga = 1.88; // w kilogramach
            var cena = 4.99M; // w złotówkach
            var owoce = "jabłka"; // ciąg znaków w cudzysłowie
            var litera = 'Z'; // znaki umieszczamy między apostrofami
            var radosc = true; // typ bool przyjmuje wartości true lub false

            // dobre użycie słowa kluczowego var
            var xml1 = new XmlDocument();
            // niepotrzebnie powtórzona nazwa typu XmlDocument
            XmlDocument xml2 = new XmlDocument();
            // złe użycie słowa kluczowego var; jaki typ otrzyma zmienna plik1?
            // var plik1 = File.CreateText(@"C:\plik.txt");
            // dobre użycie jawnej deklaracji typu
            // StreamWriter plik2 = File.CreateText(@"C:\plik.txt");

            WriteLine($"{default(int)}"); // 0
            WriteLine($"{default(bool)}"); // False
            WriteLine($"{default(DateTime)}"); // 1/01/0001 00:00:00

            int NieMogeBycNull = 4;
            int? MogeBycNull = null;
            WriteLine(MogeBycNull.GetValueOrDefault()); // 0
            MogeBycNull = 4;
            WriteLine(MogeBycNull.GetValueOrDefault()); // 4

            // przed użyciem zmiennej mojaZmienna sprawdź, czy ma ona wartość null
            //if (MojaZmienna != null)
            //{
                // zrob cos ze zmienną
            //}
            string nazwiskoAutora = null;
            // jeżeli zmienna nazwiskoAutora ma wartość null, to nie jest rzucany wyjątek,
            // ale zwracana jest wartość null
            int? ileLiter = nazwiskoAutora?.Length;

            // jeżeli zmienna ileLiter ma wartość null, to wynik otrzyma wartość 3
            var wynik = ileLiter ?? 3;
            WriteLine(wynik);

            // deklarowanie welkości tablicy
            string[] imiona = new string[4];
            // zapisywanie imion pod różnymi indeksami
            imiona[0] = "Kasia";
            imiona[1] = "Jacek";
            imiona[2] = "Joasia";
            imiona[3] = "Tomek";

            for (int i = 0; i < imiona.Length; i++)
            {
                WriteLine(imiona[i]); // odczytanie wartości pod indeksem
            }
            WriteLine($"Polska ma {populacja} mieszkanców.");
            WriteLine($"Polska ma {populacja:N0} mieszkanców.");
            WriteLine($"{waga}kg {owoce} kosztuje {cena:C}");

            Write("Podaj swoje imie i naciśnij ENTER");
            string imie = ReadLine();
            Write("Podaj swój wiek i naciśnij ENTER");
            string wiek = ReadLine();
            WriteLine($"Cześć, {imie}, dobrze wyglądasz jak na {wiek}");
        }
    }
    class Address
    {
        string? Budynek; // może mieć wartość null
        string Ulica = "Lisa"; // musi mieć wartość
        string Miasto = "Katowice"; // musi mieć wartość
        string Region = "Śląsk"; // musi mieć wartość         
    }
}