using System;

namespace Lab_5
{
    internal static class Functions
    {
        public static int FindMax(TSeries[] series, int n)
        {
            double max = series[0].GetElement(n);
            int result = 0;

            for (int i = 1; i < series.Length; i++)
            {
                if (max < series[i].GetElement(n))
                {
                    max = series[i].GetElement(n);
                    result = i;
                }
            }
            return result;
        }

        public static int Input(string text)
        {
            while (true)
            {
                Console.Write(text);

                if (int.TryParse(Console.ReadLine(), out int n))
                    return n;
                else
                {
                    Console.WriteLine("Введіть коректні дані!");
                    continue;
                }
            }
        }

        public static void FillProgressions(TSeries[] series, int firstELementLower = 1, int firstELementUpper = 50, int differenceMin = 2, int differenceMax = 10)
        {
            for (int i = 0; i < series.Length; i++)
            {
                if (i % 2 == 0)
                    series[i] = new GeometricProgression(new Random().Next(firstELementLower, firstELementUpper), new Random().Next(differenceMin, differenceMax));
                else
                    series[i] = new ArithmeticProgression(new Random().Next(firstELementLower, firstELementUpper), new Random().Next(differenceMin, differenceMax));
            }
        }

        public static void PrintSeries(TSeries[] series, int maxNum)
        {
            for (int i = 0; i < series.Length; i++)
                series[i].PrintSeries(maxNum);
        }
    }
}