using System;

namespace Lab_5
{
    internal class TSeries
    {
        public int FirstElement { get; set; }
        public int Difference { get; set; }
        public virtual int GetElement(int n)
        {
            return 0;
        }

        public virtual double SumElement(int n)
        {
            return 0;
        }

        public void PrintSeries(int n)
        {
            int i = 1;

            n = ++n;

            while (i < n)
            {
                if (i < n - 1)
                    Console.Write($"{GetElement(i)}, ");
                else
                    Console.Write($"{GetElement(i)}...\n");
                i++;
            }
        }

        public TSeries(int FirstElement, int Difference)
        {
            this.FirstElement = FirstElement;
            this.Difference = Difference;
        }
    }
}
