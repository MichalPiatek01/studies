namespace CS7
{
    public struct WektorPrzesuniencia
    {
        public int X;
        public int Y;

        public WektorPrzesuniencia(int poczatkoweX, int poczatkoweY)
        {
            X = poczatkoweX;
            Y = poczatkoweY;
        }

        public static WektorPrzesuniencia operator +(WektorPrzesuniencia wektor1, WektorPrzesuniencia wektor2)
        {
            return new WektorPrzesuniencia(wektor1.X + wektor2.X, wektor1.Y + wektor2.Y);
        }
    }
}