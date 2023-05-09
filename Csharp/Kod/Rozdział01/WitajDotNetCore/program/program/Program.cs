using System.Linq;
using System.Reflection;

using System;

namespace WitajDotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.DataSet ds;
            System.Net.Http.HttpClient client;
            // przejrzyj w pętli zestawy, do których odwołuje się aplikacja
            foreach (var r in Assembly.GetEntryAssembly()
            .GetReferencedAssemblies())
            {
                // załaduj zestaw, żeby można było odczytać szczegóły na jego temat
                var a = Assembly.Load(new AssemblyName(r.FullName));
                // zadeklaruj zmienną zliczającą ogólną liczbę metod;
                int methodCount = 0;
                // przejrzyj w pętli wszystkie typy z zestawu
                foreach (var t in a.DefinedTypes)
                {
                    // zsumuj liczbę metod
                    methodCount += t.GetMethods().Count();
                }
                // wypisz liczbę typów i ich metod
                Console.WriteLine($"W zestawie {r.Name} jest {a.DefinedTypes.Count():N0} typów " +
                    $"i {methodCount:N0} metod");
            }
        }
    }
}