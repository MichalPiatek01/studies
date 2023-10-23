using System;
using static System.Console;
using System.Reflection;
using PracaZRefleksja;

namespace CS7
{
    class PracaZRefleksja
    {
        static void Main(string[] args)
        {
            WriteLine("Metadane zestawu:");
            Assembly zestaw = Assembly.GetEntryAssembly();
            WriteLine($"Nazwa: {zestaw.FullName}");
            WriteLine($"Lokalizacja: {zestaw.Location}");
            var atrybuty = zestaw.GetCustomAttributes();
            WriteLine($"Atrybuty:");
            foreach (Attribute a in atrybuty)
            {
                WriteLine($" {a.GetType()}");
            }

            var wersja = zestaw.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($" Wersja: {wersja.InformationalVersion}");
            var firma = zestaw.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($" Firma: {firma.Company}");

            // Tworzenie własnych atrybutów
            WriteLine($"Typy:");
            Type[] typy = zestaw.GetTypes();
            foreach (Type typ in typy)
            { 
                WriteLine($" Nazwa: {typ.FullName}");
                MemberInfo[] elementy = typ.GetMembers();
                foreach (MemberInfo element in elementy)
                {
                    WriteLine($" {element.MemberType}: {element.Name} ({ element.DeclaringType.Name})");
                    var programisci = element.GetCustomAttributes<ProgramistaAttribute>().OrderByDescending(c => c.OstatnioZmienione);
                    foreach (ProgramistaAttribute programista in programisci)
                    {
                        WriteLine($" Zmienione przez {programista.Programista} w dniu { programista.OstatnioZmienione.ToShortDateString()}");
                    }
                }
            }
        }

        [Programista("Mark Price", "22 sierpnia 2017")]
        [Programista("Jan Radziewicz", "13 maja 2018")]
        public static void DoStuff()
        {
        }
    }
}