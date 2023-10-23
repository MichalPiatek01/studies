using System.Numerics;
using static System.Console;

namespace CS7
{
    class PracaZLiczbami
    {
        static void Main(string[] args)
        {
            // Praca z wielkimi liczbami całkowitymi
            var najwiekszaLiczba = ulong.MaxValue;
            WriteLine($"{najwiekszaLiczba,40:N0}");
            var liczbaAtomowWeWszechswiecie = BigInteger.Parse("123456789012345678901234567890");
            WriteLine($"{liczbaAtomowWeWszechswiecie,40:N0}");

            // Praca z liczbami zespolonymi
            var z1 = new Complex(4, 2);
            var z2 = new Complex(3, 7);
            var z3 = z1 + z2;
            WriteLine($"{z1} dodana do {z2} daje {z3}");
        }
    }
}