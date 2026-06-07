using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public static class Menu
    {
        private static List<Person> database = new List<Person>();

        public static void InitDatabase()
        {
            database.Add(new Person("Шевченко", "Тарас", 185, 80, "Україна", "+380991234567"));
            database.Add(new Student("Франко", "Іван", 175, 70, "Україна", "+380501112233", "Мечникова", 3, "Філологічний", new List<int> { 95, 90, 88 }));
            database.Add(new Employee("Міцкевич", "Ілля", 205, 90, "Польща", "+380679998877", "IT-Corp", "Розробник", 45000.0));
        }

        public static void PrintAll()
        {
            Console.Clear();
            if (database.Count == 0)
            {
                Console.WriteLine("База даних порожня.");
                return;
            }

            Console.WriteLine("Список записів:");
            foreach (Person person in database)
            {
                Console.WriteLine(person.ToString());
            }
            Console.ReadKey();
        }

        public static void AddPerson(int type)
        {
            Console.Clear();
            Console.Write("Введіть прізвище: ");
            string fName = Console.ReadLine() ?? "";
            Console.Write("Введіть ім'я: ");
            string lName = Console.ReadLine() ?? "";
            Console.Write("Введіть зріст (см): ");
            int height = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введіть вагу (кг): ");
            int weight = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введіть країну проживання: ");
            string country = Console.ReadLine() ?? "";
            Console.Write("Введіть номер телефону: ");
            string phone = Console.ReadLine() ?? "";

            if (type == 1)
            {
                database.Add(new Person(fName, lName, height, weight, country, phone));
            }
            else if (type == 2)
            {
                Console.Write("Введіть ВНЗ: ");
                string uni = Console.ReadLine() ?? "";
                Console.Write("Введіть курс: ");
                int course = int.Parse(Console.ReadLine() ?? "1");
                Console.Write("Введіть факультет: ");
                string faculty = Console.ReadLine() ?? "";
                Console.Write("Введіть оцінки через пробіл: ");
                string gradesInput = Console.ReadLine() ?? "";

                List<int> grades = new List<int>();
                foreach (string g in gradesInput.Split(' '))
                {
                    if (int.TryParse(g, out int grade))
                        grades.Add(grade);
                }

                database.Add(new Student(fName, lName, height, weight, country, phone, uni, course, faculty, grades));
            }
            else if (type == 3)
            {
                Console.Write("Введіть Завод/Компанію: ");
                string comp = Console.ReadLine() ?? "";
                Console.Write("Введіть Посаду: ");
                string pos = Console.ReadLine() ?? "";
                Console.Write("Введіть Оклад: ");
                double salary = double.Parse(Console.ReadLine() ?? "0");

                database.Add(new Employee(fName, lName, height, weight, country, phone, comp, pos, salary));
            }

            Console.WriteLine("Запис успішно додано!");
            Console.ReadKey();
        }

        public static void RemovePerson()
        {
            Console.Clear();
            Console.Write("Введіть прізвище для видалення: ");
            string targetName = Console.ReadLine() ?? "";

            Person personToRemove = null;

            foreach (Person p in database)
            {
                if (p.FirstName.ToLower() == targetName.ToLower())
                {
                    personToRemove = p;
                    break;
                }
            }

            if (personToRemove != null)
            {
                database.Remove(personToRemove);
                Console.WriteLine("Запис видалено.");
            }
            else
            {
                Console.WriteLine("Нікого не знайдено.");
            }
            Console.ReadKey();
        }

        public static void SearchPerson()
        {
            Console.Clear();
            Console.Write("Введіть прізвище для пошуку: ");
            string targetName = Console.ReadLine() ?? "";

            List<Person> results = new List<Person>();

            foreach (Person p in database)
            {
                if (p.FirstName.ToLower() == targetName.ToLower())
                {
                    results.Add(p);
                }
            }

            if (results.Count > 0)
            {
                Console.WriteLine($"Знайдено {results.Count} запис(ів):");
                foreach (Person p in results)
                {
                    Console.WriteLine(p.ToString());
                    Console.WriteLine($" Зріст > 200 см? {p.IsHeightOver200()}");
                    Console.WriteLine($" Живе у Польщі? {p.LivesInPoland()}");
                }
            }
            else
            {
                Console.WriteLine("Нікого не знайдено.");
            }
            Console.ReadKey();
        }

        public static void PrintStudentsWithScholarship()
        {
            Console.Clear();
            List<Student> studentsWithScholarship = new List<Student>();

            foreach (Person p in database)
            {
                if (p is Student student)
                {
                    if (student.GetScholarshipType() != "немає")
                    {
                        studentsWithScholarship.Add(student);
                    }
                }
            }

            if (studentsWithScholarship.Count == 0)
            {
                Console.WriteLine("Студентів, які отримують стипендію, не знайдено.");
                return;
            }

            Console.WriteLine("Студенти, які отримують стипендію:");
            foreach (Student student in studentsWithScholarship)
            {
                Console.WriteLine(student.ToString());
            }
            Console.ReadKey();
        }

        public static void ChangeEmployeePosition()
        {
            Console.Clear();
            Console.Write("Введіть прізвище працівника: ");
            string targetName = Console.ReadLine() ?? "";

            foreach (Person p in database)
            {
                if (p is Employee emp && emp.FirstName.ToLower() == targetName.ToLower())
                {
                    Console.Write($"Поточна посада: {emp.Position}. Введіть нову посаду: ");
                    string newPos = Console.ReadLine() ?? "";
                    emp.ChangePosition(newPos);
                    Console.WriteLine("Посаду успішно змінено!");
                    Console.ReadKey();
                    return; 
                }
            }
            Console.WriteLine("Працівника з таким прізвищем не знайдено.");
            Console.ReadKey();
        }

        public static void IncreaseEmployeeSalary()
        {
            Console.Clear();
            Console.Write("Введіть прізвище працівника: ");
            string targetName = Console.ReadLine() ?? "";

            foreach (Person p in database)
            {
                if (p is Employee emp && emp.FirstName.ToLower() == targetName.ToLower())
                {
                    emp.IncreaseSalary();
                    Console.WriteLine($"Оклад успішно збільшено! Новий оклад: {emp.Salary:F2} грн.");
                    Console.ReadKey();
                    return; 
                }
            }
            Console.WriteLine("Працівника з таким прізвищем не знайдено.");
            Console.ReadKey();
        }
    }
}

