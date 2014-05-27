using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student
    {
        public Student(int id, string firstName, string middleInitial,
            string lastName, DateTime dateOfBirth, int graduationYear,
            Gender gender, string birthCity, State birthState,
            string residenceCity, State residenceState
            )
        {
            Id = id;
            Gender = gender;
            FirstName = firstName;
            MiddleInitial = middleInitial;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            GraduationYear = graduationYear;
            CityOfResidence = residenceCity;
            StateOfResidence = residenceState;
            BirthCity = birthCity;
            BirthState = birthState;

        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }
        public string MiddleInitial { get; private set; }
        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public Gender Gender { get; private set; }

        public int GraduationYear { get; set; }

        public String BirthCity { get; set; }
        public State BirthState { get; set; }
        public String CityOfResidence { get; set; }
        public State StateOfResidence { get; set; }
    }
}
