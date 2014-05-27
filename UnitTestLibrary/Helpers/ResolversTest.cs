using AutoMapper;
using Domain.Models;
using NUnit.Framework;
using StudentApplication.Helpers;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLibrary.Helpers
{
    [TestFixture]
    public class ResolversTest
    {
        [SetUp]
        public void SetUp(){
            AutoMapper.Mapper.CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.ResolveUsing<FullNameResolver>())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Age, opt => opt.ResolveUsing<DateOfBirthResolver>())
                .ForMember(dest => dest.Grade, opt => opt.Ignore());
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void DateOfBirthResolverTest(){
            var source = new Student(1, String.Empty,
                String.Empty, String.Empty, DateTime.Today.AddYears(-10),
                2020, Gender.FEMALE, String.Empty, State.TEXAS, String.Empty,
                State.PENNSYLVANIA);

            var result = Mapper.Map<Student, StudentViewModel>(source);

            Assert.AreEqual(10, result.Age);
        }

        [Test]
        public void DateOfBirthInFutureResolver(){
            var source = new Student(1, String.Empty,
                String.Empty, String.Empty, DateTime.Today.AddYears(1),
                2020, Gender.FEMALE, String.Empty, State.TEXAS, String.Empty,
                State.PENNSYLVANIA);

            var result = Mapper.Map<Student, StudentViewModel>(source);

            Assert.AreEqual(-1, result.Age);
        }

        [Test]
        public void FullNameResolver(){
            var source = new Student(1, "Tom",
                String.Empty, "Jones", DateTime.Today.AddYears(1),
                2020, Gender.FEMALE, String.Empty, State.TEXAS, String.Empty,
                State.PENNSYLVANIA);

            var result = Mapper.Map<Student, StudentViewModel>(source);

            Assert.AreEqual("Tom Jones", result.FullName);
        }

        [Test]
        public void FullNameResolverEmpty(){
            var source = new Student(1, String.Empty,
                String.Empty, String.Empty, DateTime.Today.AddYears(1),
                2020, Gender.FEMALE, String.Empty, State.TEXAS, String.Empty,
                State.PENNSYLVANIA);

            var result = Mapper.Map<Student, StudentViewModel>(source);

            Assert.AreEqual(" ", result.FullName);
        }
        


    }
}
