#include <iostream>
#include <cmath>
#include <Windows.h>

double invitation(char c);

int main()
{

    SetConsoleCP(1251);                                
    SetConsoleOutputCP(1251);

    double a, b, c, x, y = 0;

    a = invitation('a');
    b = invitation('b');
    c = invitation('c');
    x = invitation('x');
    y = invitation('y');

    if ((a <= x && b <= y) || (a <= y && b <= x))
        std::cout << "Входить сторонами a та b." << std::endl;
    else if ((b <= x && c <= y) || (b <= y && c <= x))
        std::cout << "Входить сторонами b та c." << std::endl;
    else if((a <= x && c <= y) || (a <= y && c <= x))
        std::cout << "Входить сторонами a та c." << std::endl;
    else
        std::cout << "Цеглина не входить у отвір!" << std::endl;
}

double invitation(char c)
{
    double temp;
    while (true)
    {
            std::cout << "Введіть зачення ребра " << c << ": ";
            std::cin >> temp;

            if (!std::cin.good())
            {
                std::cin.clear();
                std::cin.ignore(32767, '\n');
                std::cout << "Введіть саме число!" << std::endl;
                continue;
            }
            else if (temp <= 0)
            {
                std::cout << "Число не може бути меншим, або дорівнювати 0!" << std::endl;
                continue;
            }
            else
                return temp;              
    }
}

