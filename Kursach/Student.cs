using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class Student : Person
    {
        private string university = "";
        private int courseYear;
        private string faculty = "";
        private List<int> grades;

        public string University
        {
            get { return university; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Університет не може бути порожнім");
                }
                university = value;
            }
        }
        public int CourseYear
        {
            get { return courseYear; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Курс не може бути від'ємним");
                }
                courseYear = value;
            }
        }

        public string Faculty
        {
            get { return faculty; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Факультет не може бути порожнім");
                }
                faculty = value;
            }
        }

        public List<int> Grades
        {
            get { return grades; }
            set { grades = value; }
        }

        public Student() : base()
        {
            University = "не вказано";
            CourseYear = 1;
            Faculty = "не вказано";
            Grades = new List<int>();
        }

        public Student(string firstName, string lastName, int height, int weight, string country, string phoneNumber, string university, int courseYear, string faculty, List<int> grades) : base(firstName, lastName, height, weight, country, phoneNumber)
        {
            University = university;
            CourseYear = courseYear;
            Faculty = faculty;

            if (grades == null)
            {
                Grades = new List<int>();
            }
            else
            {
                Grades = grades;
            }
        }

        public void PromoteToNextCourse()
        {
            if (Grades.Count == 0)
            {
                Console.WriteLine("Немає оцінок для переведення.");
                return;
            }

            bool canPromote = true;
            foreach (int g in Grades)
            {
                if (g < 60)
                {
                    canPromote = false;
                    break;
                }
            }

            if (canPromote)
            {
                CourseYear++;
                Console.WriteLine($"{FirstName} {LastName} переведений на {CourseYear} курс!");
            }
            else
            {
                Console.WriteLine($"{FirstName} {LastName} має оцінки нижче 60 балів, переведення неможливе.");
            }
        }

        public string GetScholarshipType()
        {
            if (Grades.Count == 0) return "немає";

            bool allExcellent = true;
            foreach (int g in Grades)
            {
                if (g < 90)
                {
                    allExcellent = false;
                    break;
                }
            }
            if (allExcellent) return "підвищена";

            double sum = 0;
            foreach (int g in Grades)
            {
                sum += g;
            }
            double average = sum / Grades.Count;

            if (average >= 75) return "звичайна";

            return "немає";
        }

        public override string ToString()
        {
            return $"[Студент] Прізвище: {FirstName}, Ім'я: {LastName}, Зріст: {Height}см, ВНЗ: {University}, Курс: {CourseYear}, Факультет: {Faculty}, Оцінки: [{string.Join(", ", Grades)}], Стипендія: {GetScholarshipType()}";
        }
    }
}