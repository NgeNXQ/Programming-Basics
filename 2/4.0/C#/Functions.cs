using System;

namespace Lab_4
{
    internal static class Functions
    {
        public static int Input(string text)
        {
            while (true)
            {
                Console.Write(text);

                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;
                else
                    Console.WriteLine("Введіть коректні дані!");
            }
        }
    }
}
