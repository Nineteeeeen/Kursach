using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Employee : Person
    {
        private string company = "";
        private string position = "";
        private double salary;
        public string Company
        {
            get { return company; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Компанія не може бути порожньою");
                }
                company = value;
            }
        }
        public string Position
        {
            get { return position; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Посада не може бути порожньою");
                }
                position = value; 
            }
        }

        public double Salary
        {
            get { return salary; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Оклад повинен бути більше 0");
                }
                salary = value;
            }
        }

        public Employee() : base()
        {
            Company = "не вказано";
            Position = "не вказано";
            Salary = 0.0;
        }

        public Employee(string firstName, string lastName, int height, int weight, string country, string phoneNumber, string company, string position, double salary) : base(firstName, lastName, height, weight, country, phoneNumber)
        {
            Company = company;
            Position = position;
            Salary = salary;
        }

        public void ChangePosition(string newPosition)
        {
            Position = newPosition;
        }

        public void IncreaseSalary()
        {
            string posLower = Position.ToLower();
            if (posLower.Contains("менеджер") || posLower.Contains("директор"))
            {
                Salary += Salary * 0.20; 
            }
            else if (posLower.Contains("розробник") || posLower.Contains("інженер"))
            {
                Salary += Salary * 0.15; 
            }
            else
            {
                Salary += Salary * 0.10; 
            }
        }

        public override string ToString()
        {
            return $"[Робітник] Прізвище: {FirstName}, Ім'я: {LastName}, Зріст: {Height}см, Країна: {Country}, Завод: {Company}, Посада: {Position}, Оклад: {Salary:F2} грн";
        }
    }
}