def invitation(side):
        while True:

            try:
                temp = float(input("Введіть значення ребра {0}: ".format(side)))

                if temp <= 0:
                    print("Ребро не може дорівнювати 0, або бути від'ємним числом!")
                    continue
                else:
                    return temp
            except ValueError:
                print("Введіть саме число!")


a, b, c, x, y = invitation('a'), invitation('b'), invitation('c'), invitation('x'), invitation('y')

if a <= x and b <= y or a <= y and b <= x:
    print("Входить сторонами a та b.")
elif b <= x and c <= y or b <= y and c <= x:
    print("Входить сторонами b та c.")
elif a <= x and c <= y or a <= y and c <= x:
    print("Входить сторонами a та c.")
else:
    print("Цеглина не пройде в отвір!")
