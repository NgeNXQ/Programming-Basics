using System;

namespace Lab_6
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

        public static int[] InputArray(int size)
        {
            int[] result = new int[size];

            for (int i = 0; i < size; i++)
                result[i] = Input($"Введіть {i + 1}-й елемент: ");

            return result;
        }

    }
}
