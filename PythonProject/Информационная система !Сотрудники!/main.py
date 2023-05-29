import json

class Employee:
    def __init__(self, firstname, lastname, gender, age, position):
        self.firstname = firstname
        self.lastname = lastname
        self.gender = gender
        self.age = age
        self.position = position

class EmployeeSystem:
    def __init__(self, filename):
        self.filename = filename
        self.load_employees()

    def load_employees(self):
        try:
            with open(self.filename, 'r') as f:
                data = json.load(f)
                self.employees = [Employee(**d) for d in data]
                print(f"Загружено {len(self.employees)} сотрудников из файла {self.filename}.")
        except FileNotFoundError:
            self.employees = []
            print(f"Файл {self.filename} не найден, создан пустой список сотрудников.")

    def save_employees(self):
        with open(self.filename, 'w') as f:
            data = [vars(e) for e in self.employees]
            json.dump(data, f, indent=4)
            print(f"Список сотрудников сохранен в файл {self.filename}.")

    def add_employee(self):
        firstname = input("Введите имя сотрудника: ")
        lastname = input("Введите фамилию сотрудника: ")
        gender = input("Введите пол сотрудника: ")
        age = int(input("Введите возраст сотрудника: "))
        position = input("Введите должность сотрудника: ")
        employee = Employee(firstname, lastname, gender, age, position)
        self.employees.append(employee)
        print(f"Сотрудник {firstname} {lastname} добавлен в список.")
        self.save_employees()

    def edit_employee(self):
        lastname = input("Введите фамилию сотрудника, которого нужно отредактировать: ")
        for employee in self.employees:
            if employee.lastname == lastname:
                firstname = input(f"Введите новое имя для сотрудника {lastname}: ")
                gender = input(f"Введите новый пол для сотрудника {lastname}: ")
                age = int(input(f"Введите новый возраст для сотрудника {lastname}: "))
                position = input(f"Введите новую должность для сотрудника {lastname}: ")
                employee.firstname = firstname
                employee.gender = gender
                employee.age = age
                employee.position = position
                print(f"Данные сотрудника {lastname} отредактированы.")
                self.save_employees()
                return
        print(f"Сотрудник с фамилией {lastname} не найден.")

    def remove_employee(self):
        lastname = input("Введите фамилию сотрудника, которого нужно удалить: ")
        for employee in self.employees:
            if employee.lastname == lastname:
                self.employees.remove(employee)
                print(f"Сотрудник {lastname} удален из списка.")
                self.save_employees()
                return
        print(f"Сотрудник с фамилией {lastname} не найден.")

    def find_employee_by_lastname(self):
        lastname = input("Введите фамилию сотрудника для поиска: ")
        found = False
        for employee in self.employees:
            if employee.lastname == lastname:
                print(f"Имя: {employee.firstname}")
                print(f"Фамилия: {employee.lastname}")
                print(f"Пол: {employee.gender}")
                print(f"Возраст: {employee.age}")
                print(f"Должность: {employee.position}")
                found = True
        if not found:
            print(f"Сотрудник с фамилией {lastname} не найден.")

    def find_employee_by_age(self):
        age = int(input("Введите возраст для поиска: "))
        found = False
        for employee in self.employees:
            if employee.age == age:
                print(f"Имя: {employee.firstname}")
                print(f"Фамилия: {employee.lastname}")
                print(f"Пол: {employee.gender}")
                print(f"Возраст: {employee.age}")
                print(f"Должность: {employee.position}")
                found = True
        if not found:
            print(f"Сотрудники в возрасте {age} не найдены.")

    def find_employee_by_letter(self):
        letter = input("Введите первую букву фамилии для поиска: ")
        found = False
        for employee in self.employees:
            if employee.lastname.startswith(letter):
                print(f"Имя: {employee.firstname}")
                print(f"Фамилия: {employee.lastname}")
                print(f"Пол: {employee.gender}")
                print(f"Возраст: {employee.age}")
                print(f"Должность: {employee.position}")
                found = True
        if not found:
            print(f"Сотрудники с фамилией, начинающейся на {letter}, не найдены.")

    def print_all_employees(self):
        if not self.employees:
            print("Список сотрудников пуст.")
        else:
            for employee in self.employees:
                print(f"Имя: {employee.firstname}")
                print(f"Фамилия: {employee.lastname}")
                print(f"Пол: {employee.gender}")
                print(f"Возраст: {employee.age}")
                print(f"Должность: {employee.position}")

    def run(self):
        while True:
            print("\nВыберите действие:")
            print("1. Добавить сотрудника")
            print("2. Редактировать данные сотрудника")
            print("3. Удалить сотрудника")
            print("4. Поиск сотрудника по фамилии")
            print("5. Поиск сотрудника по возрасту")
            print("6. Поиск сотрудников по первой букве фамилии")
            print("7. Вывод всех сотрудников")
            print("8. Выход")
            choice = input("Введите номер выбранного действия: ")
            if choice == '1':
                self.add_employee()
            elif choice == '2':
                self.edit_employee()
            elif choice == '3':
                self.remove_employee()
            elif choice == '4':
                self.find_employee_by_lastname()
            elif choice == '5':
                self.find_employee_by_age()
            elif choice == '6':
                self.find_employee_by_letter()
            elif choice == '7':
                self.print_all_employees()
            elif choice == '8':
                print("Выход из программы.")
                self.save_employees()
                break
            else:
                print("Некорректный выбор. Попробуйте еще раз.")
filename = "employees.json"
system = EmployeeSystem(filename)
system.run()