n = 0

for i in range(0, 10, 1):
    for k in range(0, 10, 1):
        n = 22200 + (i * 10) + k
        if n % 15 == 0:
            print(n)