using NUnit.Framework;
using StudentApplication.Controllers;
using StudentApplication.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using Moq;
using System.Net;
using AutoMapper;
using Domain.Models;
using StudentApplication.Helpers;

namespace UnitTestLibrary.Controllers
{
    [TestFixture]
    public class StudentControllerTest
    {
        [SetUp]
        public void SetUp()
        {
            AutoMapper.Mapper.CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.ResolveUsing<FullNameResolver>())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Age, opt => opt.ResolveUsing<DateOfBirthResolver>())
                .ForMember(dest => dest.Grade, opt => opt.Ignore());
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void GetStudentsTest()
        {
            //Arrange
            StudentController controller = new StudentController();

            //Act
            var results = 
                controller.Index() as ViewResult;
            var resultModels = results.Model as IEnumerable<StudentViewModel>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, resultModels.Count());
            Assert.IsTrue(resultModels.Any<StudentViewModel>(
                v => v.FullName.Equals("Tom Jones")));
        }

        [Test]
        public void UpdateStudentsTest()
        {
            //Arrange
            StudentController controller = new StudentController();
            Mock<StudentViewModel> model = new Mock<StudentViewModel>();

            //Act
            var result =
                controller.Edit(1, model.Object) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsTrue(controller.ModelState.IsValid);
        }

        [Test]
        public void CreateStudentsTest()
        {
            //Arrange
            StudentController controller = new StudentController();
            Mock<StudentViewModel> model = new Mock<StudentViewModel>();

            //Act
            var result =
                controller.Create(model.Object) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsTrue(controller.ModelState.IsValid);
        }

        [Test]
        public void FailToCreateStudentsTest()
        {
            //Arrange
            StudentController controller = new StudentController();
            controller.ModelState.AddModelError("Id", "Invalid id");
            Mock<StudentViewModel> model = new Mock<StudentViewModel>();

            //Act
            var result =
                controller.Create(model.Object) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [Test]
        public void CreateStudentsWithoutIdTest()
        {
            //Arrange
            StudentController controller = new StudentController();
            StudentViewModel model = new StudentViewModel()
            {
                Id = 0
            };

            //Act
            var result =
                controller.Create(model) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsTrue(controller.ModelState.IsValid);
        }

    }
}
