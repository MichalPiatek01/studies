using static System.Console;
using CS7;
using DialectSoftware.Collections;
using DialectSoftware.Collections.Generics;

namespace Zestawy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write("Podaj poprawny, szesnastkowy kod koloru: ");
            // string kolor = ReadLine();
            // WriteLine($"Czy {kolor} to poprawna wartość koloru:{ kolor.LiczbaSzesnastkowa()}");
            // Write("Podaj poprawny znacznik XML: ");
            // string xml = ReadLine();
            // WriteLine($"Czy {xml} to poprawny znacznik XML:{ xml.PoprawnyZnacznikXML()}");
            // Write("Podaj poprawne hasło: ");
            // string haslo = ReadLine();
            // WriteLine($"Czy {haslo} to poprawne hasło:{ haslo.PoprawneHaslo()}");

            var x = new Axis("x", 0, 10, 1);
            var y = new Axis("y", 0, 4, 1);
            var macierz = new Matrix<long>(new[] { x, y });
            int i = 0;
            for (; i < macierz.Axes[0].Points.Length; i++)
            {
                macierz.Axes[0].Points[i].Label = "x" + i.ToString();
            }
            i = 0;
            for (; i < macierz.Axes[1].Points.Length; i++)
            {
                macierz.Axes[1].Points[i].Label = "y" + i.ToString();
            }
            foreach (long[] c in macierz)
            {
                macierz[c] = c[0] + c[1];
            }
            foreach (long[] c in macierz)
            {
                WriteLine("{0},{1} ({2},{3}) = {4}", macierz.Axes[0].Points[c[0]].Label,
                macierz.Axes[1].Points[c[1]].Label, c[0], c[1], macierz[c]);
            }
        }
    }
}