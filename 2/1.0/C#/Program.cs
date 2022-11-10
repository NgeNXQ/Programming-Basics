using System.IO;
using System;


namespace lab_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            string text = InputText();      //Введення тексту від користувача

            WriteToFile(@"D:\VSproj\Lab_1\Files\First.txt", text);  //Створення і запис тексту в текстовий файл

            Console.WriteLine();

            Console.WriteLine("Вміст створеного файлу: ");

            ReadFromFile(@"D:\VSproj\Lab_1\Files\First.txt");       //Відкриття та читання вмісту відповідного текстового файлу

            string newText = ChangeText(GetTextFromFile(@"D:\VSproj\Lab_1\Files\First.txt"));      //Зміна тексту згідно із завдванням

            WriteToFile(@"D:\VSproj\Lab_1\Files\Second.txt", newText);      //Стоврення та запис зміненного тексту у новий файл.

            Console.WriteLine();

            Console.WriteLine("Вміст нового файлу: ");

            ReadFromFile(@"D:\VSproj\Lab_1\Files\Second.txt");           //Відкриття та читання вмісту відповідного текстового файлу
        }

        static void WriteToFile(string path, string text)       //Метод для створення та запису текста у файл
        {
            StreamWriter sw = Check(path);

            foreach (string line in text.Split('\n'))
                sw.WriteLine(line);

            sw.Close();
        }

        static string GetTextFromFile(string path)                  //Метод для зчитування тексту з файла
        {
            string result = String.Empty;

            foreach (string line in File.ReadAllLines(path))
                result += line + '\n';

            result = result.Remove(result.Length - 1);

            return result;
        }

        static void ReadFromFile(string path)                           //Метод для зчитування тексту з файлу
        {
            foreach(string line in File.ReadAllLines(path))
                Console.WriteLine(line);
        }

        static string ChangeText(string text)                   //Метод для зміни тексту
        {
            string result = String.Empty;

            string resultBegin = String.Empty;
            string resultEnd = String.Empty;

            foreach (string line in text.Split('\n'))
            {
                if (line.StartsWith('#'))                           //Зберігання рядків, які починаються з # в одну змінну, решта - в іншу
                    resultEnd += line.Remove(0, 1) + '\n';
                else
                    resultBegin += line + '\n';
            }

            result += resultBegin;

            foreach (string line in resultEnd.Split('\n'))
                result += line.Insert(line.Length / 2, "!") + '\n';         //Додавання знака оклику у середину рядка

            result = result.Remove(result.Length - 2);  

            return result;
        }

        static string InputText()                                             //Метод для введення тексту від користувача
        {
            Console.WriteLine("Введіть текст для подальших дій: ");

            string? text_result = String.Empty;
            string? temp_text = String.Empty;

            while (true)
            {
                temp_text = Console.ReadLine();                         
                    
                if (temp_text.Trim()[0] != 4)                           //Ввод здійснюється доки користувач не введе Ctrl + D
                {
                    text_result += temp_text + '\n';
                    continue;
                }
                else
                    break;   
            }

            text_result = text_result.Remove(text_result.Length - 1);

            return text_result;
        }

        static StreamWriter Check(string path)                           //Якщо текстовий документ вже інсує, то він доповнюється. Якщо не існує, то створюється
        {
            StreamWriter sw;

            if (File.Exists(path))
                sw = new StreamWriter(path, true, System.Text.Encoding.Unicode);
            else
                sw = new StreamWriter(path, false, System.Text.Encoding.Unicode);

            return sw;
        }
    }
}  