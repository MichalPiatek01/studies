using System;

namespace CS7
{
    public class WyjatekOsoba : Exception
    {
        public WyjatekOsoba(): base() { }
        public WyjatekOsoba(string message) : base(message) { }
        public WyjatekOsoba(string message, Exception innerException) : base(message, innerException) { }
    }
}
