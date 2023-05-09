using static System.Console;

namespace Debugging
{
    class Program
    {
        static double Dodaj(double a, double b)
        {
            return a + b; // celowo wprowadzony błąd
        }

        static void Main(string[] args)
        {
            double a = 4.5; // możesz też użyć słowa kluczowego var
            double b = 2.5;
            double odpowiedz = Dodaj(a, b);
            WriteLine($"{a} + {b} = {odpowiedz}");
            ReadLine(); // czekaj, aż użytkownik naciśnie ENTER
        }
    }
}
