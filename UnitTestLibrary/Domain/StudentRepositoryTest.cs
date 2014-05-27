using Domain.Models;
using Domain.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLibrary.Domain
{
    [TestFixture]
    public class StudentRepositoryTest
    {
        private IRepository<Student> _studentRepository;

        [SetUp]
        public void SetUp()
        {
            _studentRepository = new StudentRepository();
        }

        [Test]
        public void StudentRepositoryGetAllTest()
        {
            //act
            IList<Student> studentList = _studentRepository.GetAll();

            //assert
            Assert.AreEqual(3, studentList.Count);
            Assert.IsTrue(studentList.Any(t => "Tom".Equals(t.FirstName)));
        }
    }
}
