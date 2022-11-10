from datetime import datetime


def write_new_data():
    file = open("D:\\VSproj\\Lab_1_2\\File.data", 'wb')
    number = int(input("Введіть кількість товарів: "))
    for i in range(number):
        product_name = input("Введіть найменування товару: ")
        release_date = input("Введіть дату виготовлення у форматі {день}.{місяць}.{рік}: ")
        expiration_date = input("Введіть кінцевий термін у форматі {день}.{місяць}.{рік}: ")
        file.write((product_name + ' ' + release_date + ' ' + expiration_date + '\n').encode())
    file.close()


def add_data():
    file_r = open("D:\\VSproj\\Lab_1_2\\File.data", 'rb')

    text = ""
    for line in file_r:
        if line.decode() != "\n":
            text += line.decode()
    file_r.close()

    file_w = open("D:\\VSproj\\Lab_1_2\\File.data", 'wb')

    number = int(input("Введіть кількість товарів: "))
    for i in range(number):
        product_name = input("Введіть найменування товару: ")
        release_date = input("Введіть дату виготовлення у форматі {день}.{місяць}.{рік}: ")
        expiration_date = input("Введіть кінцевий термін у форматі {день}.{місяць}.{рік}: ")
        text += product_name + ' ' + release_date + ' ' + expiration_date + '\n'

    text = text.removesuffix('\n')

    for line in text.split('\n'):
        file_w.write((line + '\n').encode())

    file_w.close()


def print_info(path):
    file = open(path, 'rb')
    for line in file:
        print(line.decode(), end="")
    file.close()


def process_files():

    file = open("D:\\VSproj\\Lab_1_2\\File.data", 'rb')
    file_first = open('D:\\VSproj\\Lab_1_2\\First.data', 'wb')
    file_second = open("D:\\VSproj\\Lab_1_2\\Second.data", 'wb')

    for line in file:
        product = line.decode().split('\n')[0]

        if product != "":
            rel_date = str(product).split(' ')[1]
            exp_date = str(product).split(' ')[2]

            rel_date = datetime.strptime(rel_date, "%d.%m.%Y")
            exp_date = datetime.strptime(exp_date, "%d.%m.%Y")

            if (exp_date - rel_date).days <= 5:
                file_first.write((product + '\n').encode())
            else:
                file_second.write((product + '\n').encode())


def delete_expired():

    curr_date = datetime.today().date()

    file_r = open("D:\\VSproj\\Lab_1_2\\File.data", 'rb')
    file_first_r = open('D:\\VSproj\\Lab_1_2\\First.data', 'rb')
    file_second_r = open("D:\\VSproj\\Lab_1_2\\Second.data", 'rb')

    text = ""

    for line in file_r:
        product = line.decode().split('\n')[0]

        if product != "":
            rel_date = str(product).split(' ')[1]
            exp_date = str(product).split(' ')[2]

            rel_date = datetime.strptime(rel_date, "%d.%m.%Y").date()
            exp_date = datetime.strptime(exp_date, "%d.%m.%Y").date()

            if curr_date < exp_date:
                text += product + '\n'

    file_r.close()

    file_w = open("D:\\VSproj\\Lab_1_2\\File.data", 'wb')

    for line in text.split('\n'):
        file_w.write((line + '\n').encode())

    text = ""
    file_w.close()

    for line in file_first_r:
        product = line.decode().split('\n')[0]

        if product != "":
            rel_date = str(product).split(' ')[1]
            exp_date = str(product).split(' ')[2]

            rel_date = datetime.strptime(rel_date, "%d.%m.%Y").date()
            exp_date = datetime.strptime(exp_date, "%d.%m.%Y").date()

            if (exp_date - rel_date).days <= 5 and curr_date < exp_date:
                text += product + '\n'

    file_first_r.close()

    file_first_w = open("D:\\VSproj\\Lab_1_2\\First.data", 'wb')

    for line in text.split('\n'):
        file_first_w.write((line + '\n').encode())

    text = ""
    file_first_w.close()

    for line in file_second_r:
        product = line.decode().split('\n')[0]

        if product != "":
            rel_date = str(product).split(' ')[1]
            exp_date = str(product).split(' ')[2]

            rel_date = datetime.strptime(rel_date, "%d.%m.%Y").date()
            exp_date = datetime.strptime(exp_date, "%d.%m.%Y").date()

            if not ((exp_date - rel_date).days <= 5) and curr_date < exp_date:
                text += product + '\n'

    file_second_r.close()

    file_second_w = open("D:\\VSproj\\Lab_1_2\\Second.data", 'wb')

    for line in text.split('\n'):
        file_second_w.write((line + '\n').encode())

    file_second_w.close()
