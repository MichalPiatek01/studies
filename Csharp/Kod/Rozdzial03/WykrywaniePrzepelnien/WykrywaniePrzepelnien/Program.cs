using static System.Console;

namespace MyApp
{
    class WykrywaniePrzepelnien
    {
        static void Main(string[] args)
        {
            try
            {
                checked
                {
                    int x = int.MaxValue - 1;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                }
            }
            catch (OverflowException)
            {
                WriteLine("Wystąpiło przepełnienie ale złapałem wyjątek");
            }
            
            unchecked
            {
                int y = int.MaxValue + 1;
                WriteLine(y); // wypisze -2147483648
                y--;
                WriteLine(y); // wypisze 2147483647
                y--;
                WriteLine(y); // wypisze 2147483646
            }

            int max = 500;
            for (byte i = 0; i < max; i++)
            {
                WriteLine(i);
            }
        }
    }
}