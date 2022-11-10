from Classes import *
from Functions import *

length = int(input("Введіть кількість прогресій: "))

series = fill_progressions(length)

num_to_compare = int(input("Введіть елемент прогресії для порівняння: "))

print_progressions(series, num_to_compare)

selected_progression = find_max(series, num_to_compare)

print(f"У {selected_progression+1}-й послідовності {num_to_compare} елемент є найбільшим і дорівнює: {series[selected_progression].get_element(num_to_compare)}.")

num_sum = int(input("Введіть кількість елементів прогресії для знаходження суми: "))

print(f"Сума елементів послідовності дорівнює: {series[selected_progression].sum_element(num_sum)}")