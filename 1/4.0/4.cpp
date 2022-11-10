#include <iostream>
#include <Windows.h>

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    float result = 0.0;

    int n;

    while (true)
    {
        std::cout << "Введіть число: ";
        std::cin >> n;

        if (std::cin.good())
        {

            for (int k = 1; k <= n; k++)
            {
                result += 1 / (k * pow((2 * k + 1), 2));
            }

            std::cout << "Отриманий результат: " << result << std::endl;
            break;
        }
        else
        {
            std::cin.clear();
            std::cin.ignore(32767, '\n');
            std::cout << "Введіть саме число!" << std::endl;
            
        }
    }
}
