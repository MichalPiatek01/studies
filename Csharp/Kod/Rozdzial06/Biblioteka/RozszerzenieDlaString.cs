using System.Text.RegularExpressions;
namespace CS7
{
    public static class RozszerzeniaDlaString
    {
        public static bool AdresPoprawny(this string wejscie)
        {
            // użyj prostego wyrażenia regularnego,
            // żeby skontrolować poprawność adresu e-mail
            return Regex.IsMatch(wejscie, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}