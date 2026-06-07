using System;

namespace ConsoleApp1
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int height;
        private int weight;
        private string country;
        private string phoneNumber;

        public Person() : this("не вказано", "не вказано", 0, 0, "не вказано", "не вказано") { }

        public Person(string firstName, string lastName, int height, int weight, string country, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Height = height;
            Weight = weight;
            Country = country;
            PhoneNumber = phoneNumber;
            CheckAndFixPhoneNumber();
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Прізвище не може бути порожнім");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ім'я не може бути порожнім!");
                }
                lastName = value;
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value < 0 || value > 300)
                {
                    throw new ArgumentException("Зріст повинен бути в діапазоні від 0 до 300 см");
                }
                height = value;
            }
        }

        public int Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Вага повинна бути більшою за 0");
                }
                weight = value;
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Країна проживання не може бути порожньою");
                }
                country = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Номер телефону не може бути порожнім");
                }
                phoneNumber = value;
            }
        }

        public string IsHeightOver200()
        {
            if (height > 200)
            {
                return "Так";
            }
            else
            {
                return "Ні";
            }
        }

        public string LivesInPoland()
        {
            string lowerCountry = country.ToLower();

            if (lowerCountry == "польща" || lowerCountry == "poland")
            {
                return "Так";
            }
            else
            {
                return "Ні";
            }
        }

        public void CheckAndFixPhoneNumber()
        {
            if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.StartsWith("0"))
            {
                phoneNumber = "+38" + phoneNumber;
            }
        }

        public override string ToString()
        {
            return $"[Людина] Прізвище: {FirstName}, Ім'я: {LastName}, Зріст: {Height}см, Вага: {Weight}кг, Країна: {Country}, Тел: {PhoneNumber}";
        }
    }
}