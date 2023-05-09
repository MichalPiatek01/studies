using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Typ int zajmuje {sizeof(int)} bajtów i może przechowywać liczby z zakresu od {int.MinValue:N0} do {int.MaxValue:N0}.");
            Console.WriteLine($"Typ double zajmuje {sizeof(double)} bajtów i może przechowywać liczby z zakresu od {double.MinValue:N0} do {double.MaxValue:N0}.");
            Console.WriteLine($"Typ decimal zajmuje {sizeof(decimal)} bajtów i może przechowywać liczby z zakresu od {decimal.MinValue:N0} do {decimal.MaxValue:N0}.");
            
            decimal a = 0.1M;
            decimal b = 0.2M;
            if (a + b == 0.3M)
            {
                Console.WriteLine($"{a} + {b} jest równe 0.3");
            }
            else
            {
                Console.WriteLine($"{a} + {b} NIE jest równe 0.3");
            }
            bool radosc = true;
            bool smutek = false;
        }

    }
}
