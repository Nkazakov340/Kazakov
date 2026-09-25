using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Client : IPrimary
    {
        public int ID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Patronymic { get; }
        public DateTime BirthDay { get; }
        public Client(int id, string firstName, string lastName, string patronymic, DateTime birthDay)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            BirthDay = birthDay;
        }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDay.Year;

                if (BirthDay.Date > today.AddYears(-age))
                    age--;

                return age;
            }
        }
        public override string ToString()
        {
            return $"{ID};{FirstName};{LastName};{Patronymic};{BirthDay:dd.MM.yyyy}";
        }
    }
}
