using System.Net;
using static System.Console;
using System.Net.NetworkInformation;

namespace CS7
{
    class PracaZZasobamiSieciowymi
    {
        static void Main(string[] args)
        {
            Write("Podaj poprawny adres w internecie: ");
            string url = ReadLine();
            if (string.IsNullOrWhiteSpace(url))
            {
                url = "http://world.episerver.com/cms/?q=pagetype";
            }
            var uri = new Uri(url);
            WriteLine($"Protokół: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Ścieżka: {uri.AbsolutePath}");
            WriteLine($"Zapytanie: {uri.Query}");

            IPHostEntry daneHosta = Dns.GetHostEntry(uri.Host);
            WriteLine($"{daneHosta.HostName} ma przypisany taki adres IP:");
            foreach (IPAddress adres in daneHosta.AddressList)
            {
                WriteLine($" {adres}");
            }

            var ping = new Ping();
            PingReply odpowiedz = ping.Send(uri.Host);
            WriteLine($"{uri.Host} na wysłany ping odpowiedział: {odpowiedz.Status}.");
            if (odpowiedz.Status == IPStatus.Success)
            {
                WriteLine($"Hostowi {odpowiedz.Address} odpowiedź zajęła { odpowiedz.RoundtripTime:N0} ms");
            }
        }
    }
}