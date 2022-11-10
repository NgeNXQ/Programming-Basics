#include <iostream>
#include <time.h>
#include <Windows.h>

void print_array(double*, int);
void fill_array(double*, int, double, double);
double* arr_creation(double*, int);
void min_value(double*, double*, int);
void max_value(double*, double*, int);

int main()
{
    srand(time(NULL));

    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    int size = 0;
    int second_arr_size = 0;
    
    //Перевірка вхідних данних. Перевірка на те щоб не дорівнювало 1, бо задача не матиме сенсу
    while (true)
    {
        std::cout << "Введіть довжину масиву: ";
        std::cin >> size;

        if (std::cin.good())
            if (size > 1)
                break;
            else
                std::cout << "Розмір масиву не може бути меншим, або дорівнювати 0!. Розмір початкового масиву не може дорівнювати 1!" << std::endl;
        else
        {
            std::cin.clear();
            std::cin.ignore(32767, '\n');
            std::cout << "Введіть саме число!" << std::endl;
            continue;
        }
    }

    second_arr_size = size - 1;

    //Створення двух динамічних масивів
    double* arr = new double[size];
    double* temp_arr = new double[second_arr_size];

    //Створення і заповнення першого масиву випадковими числами
    std::cout << "Масив, заповнений випадковими числами: ";
    fill_array(arr, size, 100, -100);
    print_array(arr, size);

    std::cout << '\n';

    //Створення і заповнення другого списку модулями різниць елементів з першого
    std::cout << "Масив, заповнений модулями різниць створеного масиву: ";
    temp_arr = arr_creation(arr, second_arr_size);
    print_array(temp_arr, second_arr_size);

    double min, max = 0;

    //Встановлення і виведення найбільшого та найменшого значення з другого списку
    max_value(temp_arr, &max, size);
    min_value(temp_arr, &min, size);

    std::cout << '\n';

    std::cout << "Мінімальне значення серед модулів різниць чисел: " << min << ". Максимальне значення серед модулів різниць чисел: " << max << "." << std::endl;

    //Очищення пам'яті динамічного масиву
    delete[] arr;
    delete[] temp_arr;

    return EXIT_SUCCESS;
}

//Функція, що відповідає за вивід елементів масиву в рядок
void print_array(double* arr, int size)
{
    int temp = size - 1;

    for (int i = 0; i < size; i++)
    {
        if(i < temp)
            std::cout << *(arr + i) << ", ";
        else
            std::cout << *(arr + i) << '.';
    }
}

//Функція, що відповідає за заповнення масиву випадковими числами у заданому діапазоні
void fill_array(double* arr, int size, double upperbound, double lowerbound)
{
    for (int i = 0; i < size; i++)
        *(arr + i) = ((float(rand()) / float(RAND_MAX)) * (upperbound - lowerbound)) + lowerbound;
}

//Створює список із модулів різниць елементів створеного масиву
double* arr_creation(double* arr, int size)
{ 
    double* temp_arr = new double[size];

    for (int i = 0; i < size; i++)
         temp_arr[i] = abs(*(arr + i) - *(arr + i + 1));

    return temp_arr;
}

//Встановлення найбільшого значення масиву
void min_value(double* arr, double* min, int size)
{
    int temp_size = size - 1;

    *min = *arr;

    for (int i = 1; i < temp_size; i++)
    {
        if (*min > *(arr + i))
            *min = *(arr + i);
    }
}

//Встановлення найменшого значення масиву
void max_value(double* arr, double* max, int size)
{
    int temp_size = size - 1;

    *max = *arr;

    for (int i = 1; i < temp_size; i++)
    {
        if (*max < *(arr + i))
            *max = *(arr + i);
    }
}
