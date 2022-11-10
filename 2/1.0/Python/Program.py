import os


def input_text():                   #Ввод тексту від користувача
    result = ""
    temp_str = ""

    print("Введіть текст для подальших дій: ")

    while True:

        temp_str = input()          

        if temp_str != chr(4):                  #Закінчення вводу тексту при Ctrl + D
            result += temp_str + '\n'
        else:
            break

    result = result.removesuffix('\n')

    return result


def get_text_from_file(path):                   #Отримання тексту з файлу
    result = ""

    file = open(path, 'r')

    for line in file.readlines():
        result += line

    return result


def write_to_file(path, text):                 #Запис тексту у файл

    if os.path.exists(path):
        file = open(path, 'a')
        file.write('\n')
        file.write(text)
    else:
        file = open(path, 'w')
        file.write(text)

    file.close()


def read_from_file(path):                       #Читання тексту з файлу
    file = open(path, 'r')

    for line in file.readlines():
        print(line.removesuffix('\n'))

    file.close()

        
def change_text(text):                          #Зміна тексту відповідно до умови
    result = ""
    result_begin = ""
    result_end = ""

    for line in text.split('\n'):
        if line.startswith('#'):
            result_end += line.removeprefix('#') + '\n'
        else:
            result_begin += line + '\n'
    
    result_end = result_end.removesuffix('\n')

    result += result_begin

    for line in result_end.split('\n'):
        result += line[:int(len(line) / 2)] + '!' + line[int(len(line) / 2):] + '\n'

    result = result.removesuffix("\n")

    return result


def write_empty_line(path):                         #Перевод запису тексту у файлі на наступний рядок
    file = open(path, 'a')
    file.write('\n')
    file.close()



def main():

    text = input_text()

    write_to_file(r"D:\VSproj\Lab_1\Files\First.txt", text)

    print()

    print("Вміст текстового файлу: ")

    read_from_file(r"D:\VSproj\Lab_1\Files\First.txt")

    text = change_text(get_text_from_file(r"D:\VSproj\Lab_1\Files\First.txt"))

    write_to_file(r"D:\VSproj\Lab_1\Files\Second.txt", text)

    print()

    print("Вміст нового текстового файлу: ")

    read_from_file(r"D:\VSproj\Lab_1\Files\Second.txt")

    write_empty_line(r"D:\VSproj\Lab_1\Files\Second.txt")


if __name__ == "__main__":
    main()