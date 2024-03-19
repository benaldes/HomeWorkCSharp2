// ---- C# II (Dor Ben Dor) ----
// ben aldes
// -----------------------------
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
    public class Dice<T>  where T : IComparable<T>
    {
        protected T scalar, modifier, basedie;

        public Dice() { }
        public Dice(T scalar, T basedie, T modifier)
        {
            this.scalar = scalar;
            this.basedie = basedie;
            this.modifier = modifier;
        }
        public virtual T Roll()
        {
            throw new NotImplementedException("Roll method not implemented for generic type T.");
        }
        public override string ToString()
        {
            return scalar.ToString() + "d" + basedie.ToString() + " +" + modifier;
        }
    }

    public class Dice : Dice<int> ,IRandomProvider
    {


        public Dice(int scalar, int basedie, int modifier) : base(scalar, basedie, modifier)
        {
            this.scalar = scalar;
            this.basedie = basedie;
            this.modifier = modifier;
        }

        public override int Roll()
        {
            int value = 0;
            for (int i = 0; i < scalar; i++)
            {
                value += Random.Shared.Next(basedie);

            }
            value += modifier;
            return value;
        }
       
        
    }
}

