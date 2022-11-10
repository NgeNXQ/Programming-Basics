#include <iostream>
#include <Windows.h>

int main()
{
	int n = 0;

	for (int i = 0; i <= 9; i++)
	{
		for (int k = 0; k <= 9; k++)
		{
			n = 22200 + (i * 10) + k;
			if (n % 15 == 0)
				std::cout << n << std::endl;
		}
	}
}
