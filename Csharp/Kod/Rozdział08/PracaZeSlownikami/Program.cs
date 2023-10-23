using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Console;

namespace CS7
{
    class PracaZeSlownikami
    {
        static void Main(string[] args)
        {
            var slowaKluczowe = new Dictionary<string, string>();
            slowaKluczowe.Add("int", "typ liczb całkowitych (32-bity)");
            slowaKluczowe.Add("long", "typ liczb całkowitych (64-bity)");
            slowaKluczowe.Add("float", "liczby zmiennoprzecinkowe pojedynczej precyzji");
            WriteLine("Słowa kluczowe i ich definicje");
            foreach (KeyValuePair<string, string> element in slowaKluczowe)
            {
                WriteLine($" {element.Key}: {element.Value}");
            }
            WriteLine($"Definicja słowa kluczowego 'long' to: {slowaKluczowe["long"]}");
        }
    }
}