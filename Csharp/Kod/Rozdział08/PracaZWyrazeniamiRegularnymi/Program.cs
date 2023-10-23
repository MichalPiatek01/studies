using System.Text.RegularExpressions;
using static System.Console;

namespace CS7
{
    class PracaZWyrazeniamiRegularnymi
    {
        static void Main(string[] args)
        {
            Write("Podaj swój wiek: ");
            string wejscie = ReadLine();
            var kontrolaWieku = new Regex(@"^\d+$");
            if (kontrolaWieku.IsMatch(wejscie))
            {
                WriteLine("Dziękuję!");
            }
            else
            {
                WriteLine($"To nie jest prawidłowy wiek: {wejscie}");
            }
        }
    }
}