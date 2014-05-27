using OpenQA.Selenium;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Student
{
    public class StudentCreatePage
    {
        private static IWebDriver driver;

        public StudentCreatePage(IWebDriver webDriver)
        {
            driver = webDriver;

        }

        public StudentCreatePage NavigateTo()
        {
            driver.Navigate().GoToUrl("http://localhost:53412/Student/Create");
            return this;
        }

        //create new student
        public StudentCreatePage CreateNewStudent(StudentViewModel model)
        {
            ((IWebElement)driver.FindElement(By.Id("FullName"))).
                SendKeys(model.FullName);
            ((IWebElement)driver.FindElement(By.Id("Age"))).
                SendKeys(model.Age.ToString());

            IWebElement createElement = driver.FindElement(By.Id("Create"));
            createElement.Click();
            return this;
        }

        public string PageTitle()
        {
            return driver.Title;
        }

        public bool HasMessage(string message)
        {
            return driver.FindElements(By.TagName("span")).Any(t => t.Text == message);
        }
    }
}
