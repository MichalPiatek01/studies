using static System.Console;
using System;

namespace Argumenty
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[0], true);
            BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[1], true);

            try
            {
                WindowWidth = int.Parse(args[2]);
                WindowHeight = int.Parse(args[3]);
            }
            
            catch(PlatformNotSupportedException)
            {
                WriteLine("Aktualna platforma nie pozwala na zmianę wielkości okna konsoli.");
            }
            
            WriteLine($"Otrzymano {args.Length} argumentów");
            foreach ( string arg in args ) 
            { 
            WriteLine( arg );
            }

        }
    }
}
