using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            bool isRunning = true;

            Menu.InitDatabase();

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
                Console.WriteLine("1. Вивести всіх людей");
                Console.WriteLine("2. Додати звичайну Людину");
                Console.WriteLine("3. Додати Студента");
                Console.WriteLine("4. Додати Працівника");
                Console.WriteLine("5. Видалити за прізвищем");
                Console.WriteLine("6. Знайти людину за прізвищем");
                Console.WriteLine("7. Вивести студентів, які отримують стипендію");
                Console.WriteLine("8. Змінити посаду працівника"); 
                Console.WriteLine("9. Збільшити оклад працівнику");  
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть дію: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine(new string('-', 40));

                try
                {
                    switch (choice)
                    {
                        case "1": Menu.PrintAll();
                            break;
                        case "2": Menu.AddPerson(1);
                            break;
                        case "3": Menu.AddPerson(2);
                            break;
                        case "4": Menu.AddPerson(3);
                            break;
                        case "5": Menu.RemovePerson();
                            break;
                        case "6": Menu.SearchPerson();
                            break;
                        case "7": Menu.PrintStudentsWithScholarship();
                            break;
                        case "8": Menu.ChangeEmployeePosition();
                            break;
                        case "9": Menu.IncreaseEmployeeSalary();
                            break;
                        case "0":
                            isRunning = false;
                            Console.WriteLine("Програму завершено.");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
