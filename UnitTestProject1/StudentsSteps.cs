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
        private StudentListPage studentListPage;

        [BeforeScenario]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\dimitry\StudentApplication\StudentApplication\packages\Selenium.WebDriver.2.41.0");
            studentCreatePage = new StudentCreatePage(driver);
            studentListPage = new StudentListPage(driver);
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

        [When(@"I create new student with ""(.*)"" for FullName and (.*) for Age and ""(.*)"" for Grade")]
        public void WhenICreateNewStudentWithForFullNameAndForAgeAndForGrade(
            string fullName, int age, string grade)
        {
            StudentViewModel model = new StudentViewModel()
            {
                FullName = fullName,
                Age = age,
                Grade = grade
            };
            studentCreatePage = studentCreatePage.CreateNewStudent(model);
        }

        [When(@"I navigate to student list page")]
        public void WhenINavigateToStudentListPage()
        {
            studentListPage.NavigateTo();
        }

        [Then(@"the page should contain ""(.*)""")]
        public void ThenThePageShouldContain(string value)
        {
            Assert.IsTrue(studentListPage.HasTDElement(value));
        }


    }
}
