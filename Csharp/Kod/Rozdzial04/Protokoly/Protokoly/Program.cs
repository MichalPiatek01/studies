using System.Diagnostics;
using System.IO;

namespace Protokoly
{
    class Program
    {
        static void Main(string[] args)
        {
            // zapisuj do pliku tekstowego w folderze projektu
            Trace.Listeners.Add(new
            TextWriterTraceListener(File.CreateText("log.txt")));
            // zapisywanie tekstu jest buforowane, a ta opcja wywołuje
            // metodę Flush() we wszystkich obiektach nasłuchujących
            // po wykonaniu każdego zapisu
            Trace.AutoFlush = true;
            Debug.WriteLine("Typ Debug mówi, że już jest gotowy!");
            Trace.WriteLine("Typ Trace mówi, że już jest gotowy!");

            var ts = new TraceSwitch("Przełącznik", "Ten przełącznik sterowany jest parametrem wiersza poleceń.");
            if (args.Length > 0)
            {
                if (System.Enum.TryParse<TraceLevel>(args[0],
                ignoreCase: true, result: out TraceLevel level))
                {
                    ts.Level = level;
                }
            }
            Trace.WriteLineIf(ts.TraceError, "Poziom błędów");
            Trace.WriteLineIf(ts.TraceWarning, "Poziom ostrzeżeń");
            Trace.WriteLineIf(ts.TraceInfo, "Poziom informacji");
            Trace.WriteLineIf(ts.TraceVerbose, "Poziom ogólny");
        }
    }
}