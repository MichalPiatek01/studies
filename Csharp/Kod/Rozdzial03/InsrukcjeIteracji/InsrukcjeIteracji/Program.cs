using static System.Console;

class IterationInstructions
{
    static void Main(string[] args)
    {
        int x = 0;
        while (x < 10)
        {
            Console.WriteLine(x);
            x++ ;
        }

        string haslo = string.Empty;
        do
        {
            WriteLine("Podaj swoje haslo: ");
            haslo = ReadLine();
        } while (haslo != "sekret");
        WriteLine("Tak jest");

        for (int y = 1; y <= 10; y++)
        {
            WriteLine(y);
        }

        string[] imiona = { "Maria", "Bartek", "Dariusz" };
        foreach (string imie in imiona)
        {
            WriteLine($"{imie} ma {imie.Length} znaków");
        }
    }
}