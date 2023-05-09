using System;
using System.Collections.Generic;
using CS7;
public class WartosciDomyslne
{
    public int Populacja;
    public DateTime Kiedy;
    public string Nazwisko;
    public List<Osoba> Osoby;
    public WartosciDomyslne()
    {
        Populacja = default; // C# 7.1 i nowsze
        Kiedy = default;
        Nazwisko = default;
        Osoby = default;
    }
}
