#include <iomanip>
#include <iostream>
#include <time.h>
#include <Windows.h>
#include <iomanip>

void create_matrix(int**, int, int, int);
void print_matrix(int**, int);
int current_max(int, int, int**, int);
void examine_matrix(int**, int);

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    srand(time(NULL));

    int size = 0;

    //Створення двовимірного динамічного масиву
    std::cout << "Введіть розмір квадратичної матриці: ";
    std::cin >> size;

    int** matrix = new int* [size];

    create_matrix(matrix, size, -100, 100);

    print_matrix(matrix, size);

    std::cout << '\n';

    //Дії щодо зміни матриці
    examine_matrix(matrix, size);
    print_matrix(matrix, size);


    //Очищення пам'яті
    for (int i = 0; i < size; i++)
        delete[] matrix[i];
    delete[] matrix;

    return EXIT_SUCCESS;
}

//Створення матриці та заповнення її випадковими числами у обраному діапазоні
void create_matrix(int** matrix, int size, int lower_bound = -100, int upper_bound = 100)
{
    for (int i = 0; i < size; ++i)
        matrix[i] = new int[size];

    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
            matrix[i][j] = (rand() % (upper_bound - lower_bound + 1)) + lower_bound;
    }
}

//Виведення матриці на консоль
void print_matrix(int** matrix, int size)
{
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            std::cout << std::setw(5) << matrix[i][j] << ' ';
        }
        std::cout << '\n';
    }
}

//Знаходження максимального елемента матриці у обраному діапазоні
int current_max(int row, int column, int** matrix, int size)
{
    int first = column, last = column, max = matrix[row][column];

    for (int i = row; i < size; ++i)        
    {
        for (int j = first; j <= last; ++j)
        {
            //Порівняння двух елементів на встановлення найбільшого
            if (max < matrix[i][j]) 
                max = matrix[i][j];
        }

        //Зміна досліджуємого елемента
        if (first - 1 >= 0) 
            first--;

        if (last + 1 < size) 
            last++;      
    }
    return max;
}


//Виклик функції знаходження максимального знчення у обраному діапазоні
void examine_matrix(int** matrix, int size)
{
    for (int i = 0; i < size; ++i)
        for (int j = 0; j < size; ++j)
            matrix[i][j] = current_max(i, j, matrix, size);
}
