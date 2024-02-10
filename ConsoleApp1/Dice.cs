// ---- C# II (Dor Ben Dor) ----
// ben aldes
// -----------------------------
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
    public struct Dice : IRandomProvider
    {
        private int scalar, modifier, basedie;

        public Dice(int scalar, int basedie, int modifier)
        {
            this.scalar = scalar;
            this.basedie = basedie;
            this.modifier = modifier;
        }
        public int Roll()
        {
            int value = 0;
            for (int i = 0; i < scalar; i++)
            {
                value += Random.Shared.Next(basedie);

            }
            value += modifier;
            return value;
        }
        public override string ToString()
        {
            return scalar.ToString() + "d" + basedie.ToString() + " +" + modifier;
        }
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (this.ToString() == obj.ToString()) return true;

            return false;
        }
        public override int GetHashCode()
        {
            int haseCode = scalar ^ basedie * modifier;
            return haseCode;

        }
    }
}

