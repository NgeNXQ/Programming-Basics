using System;

namespace Lab_5
{
    internal class GeometricProgression : TSeries
    {
        public override int GetElement(int n)
        {
            return (int)(FirstElement * Math.Pow(Difference, n - 1));
        }
        public override double SumElement(int n)
        {
            return (FirstElement * (1 - Math.Pow(Difference, n))) / (1 - Difference);
        }

        public GeometricProgression(int FirstElement, int Difference) : base(FirstElement, Difference) { }
    }
}
