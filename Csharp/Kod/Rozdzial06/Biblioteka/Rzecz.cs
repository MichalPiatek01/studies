using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS7
{
    public class Rzecz
    {
        public object Dane = default(object);
        public string Obsluga(string wejscie)
        {
            if (Dane == wejscie)
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
