import math

EPSILON = 1E-6

a = float(input("Введіть число: "))
sum = 0
current = 0
previous = 0

if a >= 0 and a <= 2:

    n = 1

    current = a - 1

    sum = current

    while abs(current - previous) > EPSILON:

        n += 1

        previous = current

        current = pow((a - 1), n) / n

        if n % 2 != 0:
            sum += current
        else:
            sum -= current

    logNum = math.log(a)

    result = sum / logNum

    print(f"{round(sum, 5)} / {round(logNum, 5)} = {round(result, 1)}")

else:
    print("Введіть саме число, яке відповідає умові!")
