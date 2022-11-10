import random


def main():
    #Перевірка вхідних данних. Перевірка на те щоб не дорівнювало 1, бо задача не матиме сенсу
    while True:
        try:
            size = int(input("Введіть довжину масиву: "))
            if size > 1:
                break
            else:
                print("Розмір масиву не може бути меншим, або дорівнювати 0!. Розмір початкового масиву не може дорівнювати 1!")
                continue
        except ValueError:
            print("Введіть саме число!")
            continue

    second_arr_size = size - 1

    #Створення і заповнення першого списку випадковими числами
    print("Масив, заповнений випадковими числами: ", end = '')
    arr = fill_array(size, 100, -100)
    print_array(arr, size)

    print()

    #Створення і заповнення другого списку модулями різниць елементів з першого
    print("Масив, заповнений модулями різниць створеного масиву: ", end = '')
    temp_arr = arr_creation(arr, second_arr_size)
    print_array(temp_arr, second_arr_size)

    print()

    #Виведення найбільшого та найменшого значення з другого списку
    print(f"Мінімальне значення серед модулів різниць чисел: {min(temp_arr)}. Максимальне значення серед модулів різниць чисел: {max(temp_arr)}.")




#Функція, що відповідає за вивід елементів списку в рядок
def print_array(arr, size):
    temp = size - 1

    #Вивід елементів через коми в рядок з крапкою в кінці
    for i in range(size):
        if i < temp:
           print(f"{arr[i]}, ", end = '')
        else:
            print(f"{arr[i]}.", end = '')

#Функція, що відповідає за заповнення списку випадковими числами у заданому діапазоні
def fill_array(size, upperbound, lowerbound):
    arr = list()
    for i in range(size):
        arr.append(random.uniform(lowerbound, upperbound))

    return arr

#Створює список із модулів різниць елементів створеного списку
def arr_creation(arr, size):
    temp_arr = list()

    for i in range(size):
         temp_arr.append(abs((arr[i]) - (arr[i + 1])))

    return temp_arr


main()