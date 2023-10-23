using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaZRefleksja
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ProgramistaAttribute : Attribute
    {
        public string Programista { get; set; }
        public DateTime OstatnioZmienione { get; set; }
        public ProgramistaAttribute(string programista, string ostatnioZmienione)
        {
            Programista = programista;
            OstatnioZmienione = DateTime.Parse(ostatnioZmienione);
        }
    }
}
