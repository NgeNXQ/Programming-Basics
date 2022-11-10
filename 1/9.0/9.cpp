#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <string>

int count_words(std::string);
int last_index(std::string, int);
int return_number(std::string);
std::string return_word(std::string, int, int);

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    std::cout << "Введіть строку для розгляду: ";

    std::string input_string = "";
    std::string temp_s = "";
    int number_of_words = 0;
    int start = 0;
    int last = 0;

    int sum = 0;

    std::getline(std::cin, input_string);
    number_of_words = count_words(input_string);

    for (int i = 0; i < number_of_words; ++i)
    {
        last = last_index(input_string, start);
        temp_s = return_word(input_string, start, last);
        sum += return_number(temp_s);
        start = last;
    }

    std::cout << "Сума елементів рядка дорівнює: " << sum << '.' << std::endl;

    return EXIT_SUCCESS;
}

int return_number(std::string s)
{
    return std::stoi(s);
}


std::string return_word(std::string s, int start, int last)
{
    std::string result = "";

    for (int i = start; i < last; ++i)
    {
        if (s[i] != ' ')
            result += s[i];
        else
            continue;      
    }
    return result;
}


int last_index(std::string s, int start)
{
    int size = std::size(s);
    int index = start;
    
    for (int i = start; i < size; ++i)
    {
        if (s[i] == ' ')
        {
            index++;
            continue;
        }
        break;
    }

    while (s[index] != ' ' && index < size)
        index++;

    return index;
}

int count_words(std::string s)
{
    int size = std::size(s);
    int index = 0;
    int number_of_words = 0;

    while (index < size)
    {
        if (s[index] == ' ' || s[index] == '\0')
        {
            index++;
            continue;
        }
        else
        {
            while (s[index] != ' ' && index < size)
            {
                index++;
            }
            number_of_words++;
        }
    }
    return number_of_words;
}