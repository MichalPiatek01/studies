using static System.Console;

namespace Myapp
{
    class ObslugaWyjatkow
    {
        static void Main(string[] args)
        {
            WriteLine("Przed parsowaniem");
            WriteLine("Ile masz lat?");
            string dane = ReadLine();
            try
            {
                int wiek = int.Parse(dane);
                WriteLine($"Masz już {wiek} lat.");
            }
            catch (FormatException)
            {
                WriteLine("Podany wiek nie jest liczbą.");
            }
            catch (OverflowException)
            {
                WriteLine("Podany wiek jest liczbą, ale jest ona za duża albo za mała.");
            }
            catch(Exception ex)
            {
                WriteLine($"{ex.GetType()} z komunikatem: {ex.Message}");
            }
            WriteLine("Parsowanie zakończone");
        }

    }
}