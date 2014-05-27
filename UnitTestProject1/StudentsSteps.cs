using IntegrationTest.Student;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentApplication.Models;
using System;
using TechTalk.SpecFlow;

namespace IntegrationTest
{
    [Binding]
    public class StudentsSteps
    {
        private IWebDriver driver;
        private StudentCreatePage studentCreatePage;

        [BeforeScenario]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\dimitry\StudentApplication\StudentApplication\packages\Selenium.WebDriver.2.41.0");
            studentCreatePage = new StudentCreatePage(driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Close();
        }

        [Given(@"I navigate to create new student page")]
        public void GivenINavigateToCreateNewStudentPage()
        {
            studentCreatePage.NavigateTo();
        }

        [When(@"I create new student with ""(.*)"" for FullName and (.*) for Age")]
        public void WhenICreateNewStudentWithForFullNameAndForAge(string fullName, int age)
        {
            StudentViewModel model = new StudentViewModel()
            {
                FullName = fullName,
                Age = age
            };
            studentCreatePage = studentCreatePage.CreateNewStudent(model);
        }

        [Then(@"the result should be success")]
        public void ThenTheResultShouldBeSuccess()
        {
            Assert.AreEqual("Index", studentCreatePage.PageTitle());
        }

        [Then(@"the result should be return ""(.*)""")]
        public void ThenTheResultShouldBeReturn(string errorString)
        {
            Assert.IsTrue(studentCreatePage.HasMessage(errorString));
        }



    }
}
