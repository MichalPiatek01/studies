using System.Collections.Generic;
namespace CS7
{
    public class OsobaComparer : IComparer<Osoba>
    {
        public int Compare(Osoba x, Osoba y)
        {
            // porównaj długości nazwisk...
            int temp = x.Nazwisko.Length.CompareTo(y.Nazwisko.Length);
            /// …a jeżeli są równe…
            if (temp == 0)
            {
                // …to posortuj alfabetycznie…
                return x.Nazwisko.CompareTo(y.Nazwisko);
            }
            else
            {
                // …poza tym sortuj według długości
                return temp;
            }
        }
    }
}
