using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public IList<Student> GetAll()
        {
            return new List<Student>()
            {
                new Student(1, "Tom", String.Empty, "Jones", 
                    new DateTime(1995, 1,1), 2014, Gender.MALE, 
                    "Austin", State.TEXAS, "Austin", State.TEXAS, "Austin"),
                new Student(2, "Sally", String.Empty, "Smith", 
                    new DateTime(1996, 10,1), 2014, Gender.FEMALE, 
                    "McAllen", State.TEXAS, "Harrisburg", State.PENNSYLVANIA, "Lake Travis"),
                new Student(3, "Mack", String.Empty, "Brown", 
                    new DateTime(1997, 1,10), 2015, Gender.MALE, 
                    "Premont", State.TEXAS, "Austin", State.TEXAS, "Austin")
            };
        }
    }
}
