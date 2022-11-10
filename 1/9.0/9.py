def main():

    input_string = input("Введіть строку для розгляду: ")
    temp_s = ""
    number_of_words = 0
    start = 0
    last = 0
    sum = 0

    number_of_words = count_words(input_string)

    for i in range(0, number_of_words):
        last = last_index(input_string, start)
        temp_s = return_word(input_string, start, last)
        sum += return_number(temp_s)
        start = last

    print(f"Сума елементів рядка дорівнює: {sum}.")


def return_number(s):
    return int(s)


def return_word(s, start, last):
    result = ""

    for i in range(start, last):
        if (s[i] != ' '):
            result += s[i]
        else:
            continue

    return result


def last_index(s, start):
    size = len(s)
    index = start

    for i in range(start, size):
        if (s[i] == ' '):
            index += 1
            continue
        break

    while (index < size):
        if (s[index] != ' '):
            index += 1
        else:
            break

    return index


def count_words(s):
    size = len(s)
    index = 0
    number_of_words = 0

    while (index < size):
        if (s[index] == ' '):
            index += 1
            continue
        else:
            while (index < size):
                if(s[index] != ' '):
                    index += 1
                else:
                    break

            number_of_words += 1

    return number_of_words


main()