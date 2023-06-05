using System;
using System.Threading;

namespace CS7
{
    public static class DoKwadratu
    {
        public static double Kwadrat<T>(T wejscie) where T : IConvertible
        {
            double d = wejscie.ToDouble(Thread.CurrentThread.CurrentCulture);
            return d * d;
        }
    }
}
