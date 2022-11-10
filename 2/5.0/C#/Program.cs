namespace Lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.InputEncoding = System.Text.Encoding.UTF8;
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            TSeries[] series = new TSeries[Functions.Input("Введіть кількість прогресій: ")];

            Functions.FillProgressions(series);

            int numToCompare = Functions.Input("Введіть елемент прогресії для порівяння: ");

            Functions.PrintSeries(series, numToCompare);

            int selectedProgression = Functions.FindMax(series, numToCompare);

            Console.WriteLine($"У {selectedProgression+1}-й послідовності {numToCompare} елемент є найбільшим і дорівнює: {series[selectedProgression].GetElement(numToCompare)}.");

            int numSum = Functions.Input("Введіть кількість елементів прогресії для знаходження суми: ");

            Console.WriteLine($"Сума елементів послідовності дорівнює: {series[selectedProgression].SumElement(numSum)}");
        }
    }
}