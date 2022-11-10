from Classes import *
import random


def find_max(series, n):
    _max = series[0].get_element(n)
    result = 0

    for i in range(1, len(series)):

        if _max < series[i].get_element(n):
            _max = series[i].get_element(n)
            result = i

    return result


def fill_progressions(length, first_element_lower = 1, first_element_upper = 50, difference_min = 2, difference_max = 10):
    series = list()

    for i in range(0, length):
        if i % 2 == 0:
            series.append(GeometricProgression(random.randint(first_element_lower, first_element_upper), random.randint(difference_min, difference_max)))
        else:
            series.append(ArithmeticProgression(random.randint(first_element_lower, first_element_upper), random.randint(difference_min, difference_max)))

    return series


def print_progressions(series, max_num):
    for i in range(0, len(series)):
        series[i].print_series(max_num)