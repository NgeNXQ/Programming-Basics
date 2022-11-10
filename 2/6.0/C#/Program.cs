System.Console.InputEncoding = System.Text.Encoding.Unicode;
System.Console.OutputEncoding = System.Text.Encoding.Unicode;

int size = Lab_6.Functions.Input("Введіть кількість елементів: ");

int[] arr = Lab_6.Functions.InputArray(size);

Tree t = new Tree();

t.root = t.CreateTree(arr, 0);

Console.WriteLine();
Tree.Print(t.root);
Console.WriteLine();

Console.WriteLine($"Середнє арифметичне: {t.CountAverage()}.");