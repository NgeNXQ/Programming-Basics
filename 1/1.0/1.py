from math import sqrt

def validation():

    while True:

        try:

            number = float(input("Введіть площу квадрата: "))

            if number < 0:
                print("Площа квадрата не може бути від'ємним числом!")
                continue
            elif number == 0:
                print("Площа квадрата не може дорівнювати 0!")

        except ValueError:
            print("Введіть саме число!")
        else:
            return number


area_of_outer = validation()           #Перевірка на правильність введених даних

diameter = pow(area_of_outer, 0.5)      #Діаметер кола

square_inner = diameter / sqrt(2)       #Сторона квадрата, який вписаний у коло

area_of_inner = square_inner ** 2         #Площа вписаного у коло квадрата

print(round(area_of_inner / area_of_outer, 5))    #У скільки разів площа вписаного більша, ніж описаного







