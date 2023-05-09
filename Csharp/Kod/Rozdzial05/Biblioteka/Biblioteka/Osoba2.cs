using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CS7
{
    public partial class Osoba
    {
        // właściwości definiowane przy użyciu składni C# 1 – 5
        public string Pochodzenie
        {
            get
            {
                return $"{Nazwisko} pochodzi z planety {Planeta}";
            }
        }

        // dwie właściwości zdefiniowane przy użyciu wyrażeń lambda z C# 6
        public string Pozdrowienie => $"{Nazwisko} mówi 'Cześć!'";
        public int Wiek => (int)(System.DateTime.Today.Subtract(DataUrodzenia).TotalDays / 365.25);

        public string UlubioneLody { get; set; } // składnia automatu

        private string ulubionyKolorPodstawowy;
        public string UlubionyKolorPodstawowy
        {
            get
            {
                return ulubionyKolorPodstawowy;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "czerwony":
                    case "zielony":
                    case "niebieski":
                        ulubionyKolorPodstawowy = value;
                        break;
                    default:
                        throw new System.ArgumentException($"{value} nie jest kolorem podstawowym.Wybieraj spośród wartości: czerwony, zielony, niebieski.");
                }
            }
        }

        // indeksery
        public Osoba this[int indeks]
        {
            get
            {
                return Dzieci[indeks];
            }
            set
            {
                Dzieci[indeks] = value;
            }
        }
    }
}
