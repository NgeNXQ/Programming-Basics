using System;

namespace Lab_5
{
    internal class ArithmeticProgression : TSeries
    {
        public override int GetElement(int n) 
        {
            return FirstElement + Difference * (n - 1);
        }

        public override double SumElement(int n)
        {
            return (2 * FirstElement + Difference * (n - 1)) / 2 * n;
        }

        public ArithmeticProgression(int FirstElement, int Difference) : base(FirstElement, Difference) { }
    }
}
