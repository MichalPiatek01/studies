using static System.Console;

namespace CS7
{
    class PracaZCiagamiZnakow
    {
        static void Main(string[] args)
        {
            // Odczytywanie długości ciągu znaków
            string miasto = "Londyn";
            WriteLine($"{miasto} ma {miasto.Length} znaków.");

            // Odczytywanie znaków z ciągu
            WriteLine($"Pierwszy znak to {miasto[0]}, a trzeci to {miasto[2]}.");

            // Dzielenie ciągu znaków
            string miasta = "Paryż,Berlin,Madryt,Nowy Jork";
            string[] tablicaMiast = miasta.Split(',');
            foreach (string element in tablicaMiast)
            {
                WriteLine(element);
            }

            // Pobieranie części ciągu znaków
            string imieINazwisko = "Adam Nowak";
            int indeksSpacji = imieINazwisko.IndexOf(' ');
            string imie = imieINazwisko.Substring(0, indeksSpacji);
            string nazwisko = imieINazwisko.Substring(indeksSpacji + 1);
            WriteLine($"{nazwisko}, {imie}");

            // Poszukiwanie tekstu w ciągu
            string firma = "Microsoft";
            bool zaczynaSieOdM = firma.StartsWith("M");
            bool zawieraN = firma.Contains("N");
            WriteLine($"Zaczyna się od litery M: {zaczynaSieOdM}, zawiera literę N: {zawieraN}");

            string znowZlaczone = string.Join(" => ", tablicaMiast);
            WriteLine(znowZlaczone);

            string owoce = "jabłka";
            decimal cena = 0.39M;
            DateTime kiedy = DateTime.Today;
            WriteLine($"W {kiedy:dddd} {owoce} kosztują {cena:C}.");
            WriteLine(string.Format("W {2:dddd} {0} kosztują {1:C}.", owoce, cena, kiedy));

        }
    }
}