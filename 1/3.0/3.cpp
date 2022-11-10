#include <iostream>
#include <cmath>
#include <math.h>
#include <Windows.h>

int main()
{
	SetConsoleCP(1251);                              
	SetConsoleOutputCP(1251);

	const double EPSILON = 1E-6;

	float a = 0;
	float sum = 0;
	float current = 0;
	float previous = 0;


		std::cout << "Введіть число: ";
		std::cin >> a;

		if (std::cin.good())
		{
			if (a >= 0 && a <= 2)
			{
				int n = 1;

				current = a - 1;

				sum = current;

				while (abs(current - previous) > EPSILON)
				{

					n++;

					previous = current;

					current = powf((a - 1), n) / n;

					if (n % 2 != 0)
						sum += current;
					else
						sum -= current;

				}
					float log_num = log(a);

					float result = sum / log_num;
					std::cout << round(sum * 1E5) / 1E5 << " / " << round(log_num * 1E5) / 1E5 << " = "; std::cout << round(result) << std::endl;
			}
			else
			{
				std::cout << "Введіть число, яке відповідає умові!" << std::endl;
			}
		}
		else
		{
			std::cin.clear();
			std::cin.ignore(32767, '\n');
			std::cout << "Введіть саме число!" << std::endl;
		}
}