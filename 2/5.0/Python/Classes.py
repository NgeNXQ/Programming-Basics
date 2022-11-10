import math
from abc import ABC, abstractmethod


class TSeries(ABC):

    @abstractmethod
    def get_element(self, n):
        pass

    @abstractmethod
    def sum_element(self, n):
        pass

    def print_series(self, n):

        i = 1
        _n = n + 1

        while i < _n:
            if i < _n - 1:
                print(f"{(int)(self.get_element(i))}, ", end='')
            else:
                print(f"{(int)(self.get_element(i))}...")
            i += 1

    def __init__(self, first_element, difference):
        self.first_element = first_element
        self.difference = difference


class GeometricProgression(TSeries):

    def get_element(self, n):
        return self.first_element * math.pow(self.difference, n - 1)

    def sum_element(self, n):
        return (self.first_element * (1 - math.pow(self.difference, n))) / (1 - self.difference)

    def __init__(self, first_element, difference):
        super().__init__(first_element, difference)


class ArithmeticProgression(TSeries):

    def get_element(self, n):
        return self.first_element + self.difference * (n - 1)

    def sum_element(self, n):
        return (2 * self.first_element + self.difference * (n - 1)) / 2 * n

    def __init__(self, first_element, difference):
        super().__init__(first_element, difference)