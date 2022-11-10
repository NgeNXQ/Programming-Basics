using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Quadrangle[] quadrangles;

            while (true)
            {
                Console.Write("Скільки буде прямокутників: ");

                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    quadrangles = new Quadrangle[num];
                    break;
                }
                Console.WriteLine("Введіть коректні дані!");
            }


            for (int i = 0; i < quadrangles.Length; i++)
            {
                quadrangles[i] = new Quadrangle();
                quadrangles[i].InputPoints();

                Console.WriteLine($"Периметр {i + 1}-го прямокутника: {quadrangles[i].Perimeter}");
            }

            ShowMaxPerimeter();

            void ShowMaxPerimeter()
            {
                double max = quadrangles[0].Perimeter;

                for (int i = 1; i < quadrangles.Length; i++)
                {
                    if (quadrangles[i].Perimeter > max)
                        max = quadrangles[i].Perimeter;
                }

                Console.WriteLine($"Найбільша площа прямокутника дорівнює: {max}.");
            }
        }
    }
}
