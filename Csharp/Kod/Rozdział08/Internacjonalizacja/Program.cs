using static System.Console;
using System;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Net;

namespace CS7
{
    class Internacjonalizacja
    {
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo globalizacja = CultureInfo.CurrentCulture;
            CultureInfo lokalizacja = CultureInfo.CurrentUICulture;

            WriteLine($"Aktualna kultura globalizacji to { globalizacja.Name}: { globalizacja.DisplayName}");
            WriteLine($"Aktualna kultura lokalizacji to {lokalizacja.Name}: { lokalizacja.DisplayName}");
            WriteLine();
            WriteLine("en-US: Angielski (USA)");
            WriteLine("pl-PL: Polski (Polska)");
            WriteLine("fr-CA: Francuski (Kanada)");
            Write("Podaj kod ISO kultury: ");

            string nowaKultura = ReadLine();
            if (!string.IsNullOrEmpty(nowaKultura))
            {
                var ci = new CultureInfo(nowaKultura);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }

            Write("Jak się nazywasz: ");
            string nazwisko = ReadLine();

            Write("Podaj datę urodzenia: ");
            string dataUrodzenia = ReadLine();

            Write("Podaj, ile zarabiasz: ");
            string pensja = ReadLine();

            DateTime data = DateTime.Parse(dataUrodzenia);
            int minuty = (int)DateTime.Today.Subtract(data).TotalMinutes;
            decimal zarabia = decimal.Parse(pensja);
            WriteLine($"{nazwisko}, data urodzenia: {data:dddd} na świecie jest od { minuty:N0} minut i zarabia { zarabia:C}.");
        }
    }
}