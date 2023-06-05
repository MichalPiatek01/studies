using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS7
{
    public class GenerycznaRzecz<T> where T : IComparable, IFormattable
    {
        public T Dane = default(T);
        public string Obsluga(string wejscie)
        {
            if (Dane.ToString().CompareTo(wejscie) == 0)
            {
                return Dane.ToString() + Dane.ToString();
            }
            else
            {
                return Dane.ToString();
            }
        }
    }
}
