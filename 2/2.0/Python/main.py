from Functions import *


def main():

   op = int(input("Створити новий файл [1]? Чи доповнювати старий [2]?: "))

   if op == 1:

      write_new_data()
      process_files()

      print("\nВміст початкового файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\File.data")
      print("\nВміст першого файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\First.data")
      print("\nВміст другого файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\Second.data")

      print("\nПісля видалення: ")
      delete_expired()

      print("\nВміст початкового файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\File.data")
      print("Вміст першого файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\First.data")
      print("Вміст другого файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\Second.data")

   elif op == 2:

      add_data()
      process_files()

      print("\nВміст початкового файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\File.data")
      print("\nВміст першого файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\First.data")
      print("\nВміст другого файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\Second.data")

      print("\nПісля видалення: \n")
      delete_expired()

      print("Вміст початкового файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\File.data")
      print("Вміст першого файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\First.data")
      print("Вміст другого файлу: \n")
      print_info("D:\\VSproj\\Lab_1_2\\Second.data")


if __name__ == '__main__':
   main()