Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

int o = SelectOption("Створити новий файл [1]? Чи доповнювати старий [2]?: ");

int number = InputNumber("Введіть кількість товарів: ");

WriteToFile(@"D:\VSproj\Lab_1_2\File.data", CreateProductList(number), o);

Console.WriteLine("\nВміст початкового файлу: \n");
ReadTextFromFile(@"D:\VSproj\Lab_1_2\File.data");

DistributeText(@"D:\VSproj\Lab_1_2\File.data", @"D:\VSproj\Lab_1_2\First.data", @"D:\VSproj\Lab_1_2\Second.data");

Console.WriteLine("\nВміст файлів після розподілу: ");

Console.WriteLine("\nВміст першого файлу: \n");
ReadTextFromFile(@"D:\VSproj\Lab_1_2\First.data");
Console.WriteLine("\nВміст другого файлу: \n");
ReadTextFromFile(@"D:\VSproj\Lab_1_2\Second.data");

DeleteExpired(@"D:\VSproj\Lab_1_2\File.data", @"D:\VSproj\Lab_1_2\First.data", @"D:\VSproj\Lab_1_2\Second.data");
Console.WriteLine("\nВміст файлів після видалення: ");

Console.WriteLine("\nВміст початкового файлу: \n");
ReadTextFromFile(@"D:\VSproj\Lab_1_2\File.data");
Console.WriteLine("\nВміст першого файлу: \n");
ReadTextFromFile(@"D:\VSproj\Lab_1_2\First.data");
Console.WriteLine("\nВміст другого файлу: \n");
ReadTextFromFile(@"D:\VSproj\Lab_1_2\Second.data");


int SelectOption(string text)
{
    while (true)
    {
        Console.Write(text);

        if (int.TryParse(Console.ReadLine(), out int result))
        {
            if(result == 1 || result == 2)
                return result;
            else
                Console.WriteLine("Введіть коректні дані!");
        }
        else
            Console.WriteLine("Введіть коректні дані!");
    }
}

string CreateProductList(int number)
{
    string result = String.Empty;

    for (int i = 0; i < number; i++)
        result += InputProduct() + '\n';

    return result.Remove(result.Length - 1, 1);
}

string InputProduct()
{
    string result = String.Empty;

    Console.Write("Введіть найменування товару: ");
    result += Console.ReadLine() + " ";

    while(true)
    {
        Console.Write("Введеіть дату виготволення у форматі {місяць}.{день}.{рік}: ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime release))
        {
            result += release.ToString("dd/MM/yyyy") + " ";
            break;
        }
        else
            Console.WriteLine("Введіть у коректному форматі!");
    }

    while (true)
    {
        Console.Write("Введеіть кінцевий термін у форматі {місяць}.{день}.{рік}: ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime expire))
        {
            result += expire.ToString("dd/MM/yyyy");
            break;
        }
        else
            Console.WriteLine("Введіть у коректному форматі!");
    }
    return result;
}

int InputNumber(string text)
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

void WriteToFile(string path, string text, int o)
{
    if(o == 1)
    {
        using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            for (int i = 0; i < text.Split('\n').Length; i++)
                bw.Write(text.Split('\n')[i]);
        }
    }
    else
    {
        using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Append)))
        {
            for (int i = 0; i < text.Split('\n').Length; i++)
                bw.Write(text.Split('\n')[i]);
        }
    }
}

void ReadTextFromFile(string path)
{
    using(BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
    {
        while (br.PeekChar() > -1)
            Console.WriteLine(br.ReadString());
    }
}

string RetrunTextFromFile(string path)
{
    string text = String.Empty;

    using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
    {
        while (br.PeekChar() > -1)
            text += br.ReadString() + '\n';
    }

    return text.Remove(text.Length - 1, 1);
}

void DistributeText(string path, string path1, string path2)
{
    string text = RetrunTextFromFile(path);
    string text1 = string.Empty, text2 = String.Empty;
    DateTime dt1, dt2;

    for (int i = 0; i < text.Split('\n').Length; i++)
    {
        StringToDate(text.Split('\n')[i], out dt1, out dt2);

        if ((dt2 - dt1).TotalDays <= 5)
            text1 += text.Split('\n')[i] + '\n';
        else
            text2 += text.Split('\n')[i] + '\n';
    }
    if (!text1.Equals(""))
        text1 = text1.Remove(text1.Length - 1, 1);
    if (!text2.Equals(""))
        text2 = text2.Remove(text2.Length - 1, 1);

    WriteToFile(path1, text1, 1);
    WriteToFile(path2, text2, 1);
}

void StringToDate(string s, out DateTime dt1, out DateTime dt2)
{
    string date;

    date = s.Split(' ')[1];
    dt1 = new DateTime(Int32.Parse(date.Split('/')[2]), Int32.Parse(date.Split('/')[1]), Int32.Parse(date.Split('/')[0]));
    date = s.Split(' ')[2];
    dt2 = new DateTime(Int32.Parse(date.Split('/')[2]), Int32.Parse(date.Split('/')[1]), Int32.Parse(date.Split('/')[0]));
}

void DeleteExpired(string path, string path1, string path2)
{

    DateTime dt1, dt2;
    DateTime dt = DateTime.Now;
    string text = RetrunTextFromFile(path), text1 = RetrunTextFromFile(path1), text2 = RetrunTextFromFile(path2);
    string newText = String.Empty, newText1 = String.Empty, newText2 = String.Empty;

    for (int i = 0; i < text.Split('\n').Length; i++)
    {
        StringToDate(text.Split('\n')[i], out dt1, out dt2);

        if (dt < dt2)
            newText += text.Split('\n')[i] + '\n';
    }

    for (int i = 0; i < text1.Split('\n').Length; i++)
    {
        StringToDate(text1.Split('\n')[i], out dt1, out dt2);

        if ((dt2 - dt1).TotalDays <= 5 && dt < dt2)
            newText1 += text1.Split('\n')[i] + '\n';
    }

    for (int i = 0; i < text2.Split('\n').Length; i++)
    {
        StringToDate(text2.Split('\n')[i], out dt1, out dt2);

        if (!((dt2 - dt1).TotalDays <= 5) && dt < dt2)
            newText2 += text2.Split('\n')[i] + '\n';
    }

    if(!newText.Equals(""))
        newText = newText.Remove(newText.Length - 1, 1);
    if (!newText1.Equals(""))
        newText1 = newText1.Remove(newText1.Length - 1, 1);
    if (!newText2.Equals(""))
        newText2 = newText2.Remove(newText2.Length - 1, 1);

    WriteToFile(path, newText, 1);
    WriteToFile(path1, newText1, 1);
    WriteToFile(path2, newText2, 1);
}