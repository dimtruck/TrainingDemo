using NUnit.Framework;
using StudentApplication.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLibrary.Helpers
{
    [TestFixture]
    public class GradeRangeAttributeTest
    {
        private ValidationAttribute _gradeRangeAttribute;

        [SetUp]
        public void SetUp()
        {
            _gradeRangeAttribute = new GradeRangeAttribute("A,B,C,D,F");
        }

        [Test]
        public void GradeRangeValidRangeTest()
        {
            //act and assert
            Assert.IsTrue(_gradeRangeAttribute.IsValid("A"));
        }

        [Test]
        public void GradeRangeInvalidRangeTest()
        {
            //act and assert
            Assert.IsFalse(_gradeRangeAttribute.IsValid("AA"));
        }
    }
}
