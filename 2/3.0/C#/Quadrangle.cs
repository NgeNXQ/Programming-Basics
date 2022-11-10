using System;

    internal class Quadrangle
    {
        private Point[] dots = new Point[4];
        public double Perimeter { get => CountPerimeter(); }
        public void InputPoints()
        {
            string? input = String.Empty;
            Point p = new Point();
            int index = 0;

            while (true)
            {
                if (index >= 4)
                    break;

                Console.Write($"Введіть значення X та Y {index + 1}-ої точки опуклого прямокутника: ");

                input = Console.ReadLine();

                if (input is not null)
                {
                    if (int.TryParse(input.Split(' ')[0].Trim(), out int X) && int.TryParse(input.Split(' ')[1].Trim(), out int Y))
                    {
                        p.X = X; p.Y = Y;
                        dots[index] = p;
                        index++;
                    }
                    else
                        Console.WriteLine("Введіть коректні дані!");
            }
                else
                    Console.WriteLine("Введіть коректні дані!");
            }
        }

        private double CountPerimeter()
        {
            double result = 0;

            for (int i = 1; i < 4; i++)
                result += CalculateLength(dots[i - 1], dots[i]);

            result += CalculateLength(dots[0], dots[3]);

            return result;

            double CalculateLength(Point p1, Point p2) => Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        }

        struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point() { X = 0; Y = 0; }

            public Point(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }
    }
