using System.Text.RegularExpressions;
namespace CS7
{
    public static class RozszerzeniaDlaString
    {
        public static bool PoprawnyZnacznikXML(this string wejscie)
        {
            return Regex.IsMatch(wejscie, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }
        public static bool PoprawneHaslo(this string wejscie)
        {
            // przynajmniej osiem poprawnych znaków
            return Regex.IsMatch(wejscie, "^[a-zA-Z0-9_-]{8,}$");
        }
        public static bool LiczbaSzesnastkowa(this string wejscie)
        {
            // trzy lub sześć poprawnych cyfr szesnastkowych
            return Regex.IsMatch(wejscie, "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
    }
}