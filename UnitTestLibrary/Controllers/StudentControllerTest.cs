﻿using NUnit.Framework;
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

namespace UnitTestLibrary.Controllers
{
    [TestFixture]
    public class StudentControllerTest
    {
        private Mock<StudentViewModel> model = new Mock<StudentViewModel>();


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
        public void CreateStudentsTest()
        {
            //Arrange
            StudentController controller = new StudentController();
            
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

            //Act
            var result =
                controller.Create(model.Object) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(controller.ModelState.IsValid);
        }
    }
}
