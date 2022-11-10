Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

Line P1 = new Line();
Line P2 = new Line(Lab_4.Functions.Input("Введіть координати с: "));
Line P3 = new Line(Lab_4.Functions.Input("Введіть координати a: "), Lab_4.Functions.Input("Введіть координати b: "), Lab_4.Functions.Input("Введіть координати c: "));

Console.WriteLine();

Console.WriteLine($"Перша пряма: {P1}");
Console.WriteLine($"Друга пряма: {P2}");
Console.WriteLine($"Третя пряма: {P3}");

Console.WriteLine();

if (P1 | P2)
    Console.WriteLine("P1 та P2 паралельні.");
else
    Console.WriteLine("P1 та P2 не паралельні.");

Console.WriteLine();

P3++;

Console.WriteLine($"Третя пряма після збільшення на 1 градус: {P3}");

Console.WriteLine();

Console.WriteLine($"Точка перетину з віссю Х: ({P3.IntersectionX}; 0).");
Console.WriteLine($"Точка перетину з віссю Y: (0; {P3.IntersectionY}).");