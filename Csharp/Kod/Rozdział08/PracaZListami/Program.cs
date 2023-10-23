using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Console;
using System.Collections.Immutable;

namespace CS7
{
    class PracaZListami
    {
        static void Main(string[] args)
        {
            var miasta = new List<string>();
            miasta.Add("Londyn");
            miasta.Add("Paryż");
            miasta.Add("Mediolan");

            WriteLine("Początkowa lista");

            foreach (string miasto in miasta)
            {
                WriteLine($" {miasto}");
            }

            WriteLine($"Pierwszym miastem jest {miasta[0]}.");
            WriteLine($"Ostatnim miastem jest {miasta[miasta.Count - 1]}.");
            miasta.Insert(0, "Sydney");
            WriteLine("Po dodaniu Sydney pod indeksem 0");

            foreach (string miasto in miasta)
            {
                WriteLine($" {miasto}");
            }

            miasta.RemoveAt(1);
            miasta.Remove("Mediolan");
            WriteLine("Po usunięciu dwóch miast");
            
            foreach (string miasto in miasta)
            {
                WriteLine($" {miasto}");
            }

            // Używanie kolekcji niezmiennych
            var niezmienneMiasta = miasta.ToImmutableList();
            var nowaLista = niezmienneMiasta.Add("Rio");
            Write("Niezmienne miasta:");
            foreach (string miasto in niezmienneMiasta)
            {
                Write($" {miasto}");
            }
            WriteLine();
            Write("Nowe miasta:");
            foreach (string miasto in nowaLista)
            {
                Write($" {miasto}");
            }
            WriteLine();
        }
    }
}