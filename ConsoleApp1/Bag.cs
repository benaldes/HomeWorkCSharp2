using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public struct Bag : IRandomProvider
    {
        private int amount;
        private List<int> bagCount = new List<int>();

        public Bag(int amount)
        {
            this.amount = amount;
            InitsBag();
        }
        private void  InitsBag()
        {
            for(int i = 1; i <= amount; i++) 
            { 
                bagCount.Add(i);
            }
        }

        public int Roll()
        {
            if(bagCount.Count == 0)
                InitsBag();
            int index = Random.Shared.Next(0, bagCount.Count);
            int value = bagCount[index];
            bagCount.Remove(index);
            return value;
        }
        /*public override string ToString()
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

        }*/
    }
    
}
