
result = 0.0

while(True):

    try:
        n = int(input("Введіть число n: "))

        for k in range(1, n + 1):
            result += 1 / (k * pow((2 * k + 1), 2))

        print(f"Результат: {result}")
        break

    except ValueError:
        print("Введіть саме число!")




