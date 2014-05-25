using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student
    {
        public Student(int id, string fullName, int age, Gender gender)
        {
            Id = id;
            FullName = fullName;
            Age = age;
            Gender = gender;
        }

        public int Id { get; private set; }

        public string FullName { get; private set; }

        public int Age { get; private set; }

        public Gender Gender { get; private set; }
    }
}
