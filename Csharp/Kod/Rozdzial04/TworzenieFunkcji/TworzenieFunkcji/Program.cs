using System.Runtime.CompilerServices;
using static System.Console;

namespace WritingFunctions
{
    class Program
    {
        static void TabliczkaMnozenia(byte liczba)
        {
            WriteLine($"To jest sekwencja mnożenia dla liczby {liczba}");
            for (int wiersz = 1; wiersz <= 12; wiersz++)
            {
                WriteLine($" {wiersz} x {liczba} = {wiersz * liczba}");
            }
        }

        static void WypiszTabliczkeMnozenia()
        {
            WriteLine("Podaj liczbę od 0 do 255: ");
            if (byte.TryParse(ReadLine(), out byte liczba))
            {
                TabliczkaMnozenia(liczba);
            }
            else
            {
                WriteLine("Proszę wpisać prawidłową liczbę");
            }
        }

        static void Main(string[] args)
        {
            // WypiszTabliczkeMnozenia();
            // ObliczPodatekVAT();
            // ZmienGlowneNaPorzadkowe();
            ObliczSilnie();
        }

        static decimal PodatekVAT(decimal kwota, string kodRegionu)
        {
            decimal stawka = 0.0M;
            switch (kodRegionu)
            {
                case "CH": // Szwajcaria
                    stawka = 0.08M;
                    break;
                case "DK": // Dania
                case "NO": // Norwegia
                    stawka = 0.25M;
                    break;
                case "GB": // Wielka Brytania
                case "FR": // Francja
                    stawka = 0.2M;
                    break;
                case "HU": // Węgry
                    stawka = 0.27M;
                    break;
                case "OR": // Oregon
                case "AK": // Alaska
                case "MT": // Montana
                    stawka = 0.0M;
                    break;
                case "ND": // Dakota Północna
                case "WI": // Wisconsin
                case "ME": // Maryland
                case "VA": // Wirginia
                    stawka = 0.05M;
                    break;
                case "CA": // Kalifornia
                    stawka = 0.0825M;
                    break;
                default: // Polska
                    stawka = 0.23M;
                    break;
            }
            return kwota * stawka;
        }

        static void ObliczPodatekVAT()
        {
            WriteLine("Podaj kwotę: ");
            string kwotaJakoTekst = ReadLine();
            Write("Podaj dwuliterowy kod regionu: ");
            string region = ReadLine();
            if (decimal.TryParse(kwotaJakoTekst, out decimal kwota))
            {
                decimal Podatek = PodatekVAT(kwota, region);
                WriteLine($"Musisz zapłacić {Podatek} podatku VAT.");
            }
            else
            {
                WriteLine("Nie podano prawidłowej kwoty!");
            }
        }

        static string GlownePorzadkowe(int liczba)
        {
            switch (liczba)
            {
                case 11:
                case 12:
                case 13:
                    return $"{liczba}th";
                default:
                    string liczbaJakoTekst = liczba.ToString();
                    char ostatniaCyfra = liczbaJakoTekst[liczbaJakoTekst.Length - 1];
                    string przyrostek = string.Empty;
                    switch (ostatniaCyfra)
                    {
                        case '1':
                            przyrostek = "st";
                            break;
                        case '2':
                            przyrostek = "nd";
                            break;
                        case '3':
                            przyrostek = "rd";
                            break;
                        default:
                            przyrostek = "th";
                            break;
                    }
                    return $"{liczba}{przyrostek}";
            }
        }

        static void ZmienGlowneNaPorzadkowe()
        {
            for (int liczba = 1; liczba <= 40; liczba++)
            {
                Write($"{GlownePorzadkowe(liczba)} ");
            }
        }

        static int Silnia(int liczba)
        {
            if (liczba < 0)
            {
                return 0;
            }
            else if (liczba == 1)
            {
                return 1;
            }
            else
            {
                return liczba * Silnia(liczba - 1);
            }
        }

        static void ObliczSilnie()
        {
            WriteLine("Podaj liczbę: ");
            if (int.TryParse(ReadLine(), out int liczba))
            {
                WriteLine($"{liczba:N0}! = {Silnia(liczba):N0}");
            }
            else
            {
                WriteLine("Podaj prawidłową liczbę.");
            }
        }
    }
}