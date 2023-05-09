using static System.Console;

namespace Działania
{
    class Program
    {
        static void Main(string[] args)
        {
            // Większość operatorów jest dwuargumentowa
            //var wynikOperacji = pierwszyArgument operator drugiArgument;
            // Część operatorów jest jednoargumentowa
            //var wynikOperacji = pierwszyArgument operator;
            // Istnieją też operatory trójargumentowe
            //var wynikOperacji = pierwszyArgument pierwszyOperator drugiArgument drugiOperator trzeciArgument;

            int i = 3;
            Console.WriteLine(i);
            //int y = i++;
            int y = ++i;
            Console.WriteLine(y);
            Console.WriteLine(i);

        }
    }
}
