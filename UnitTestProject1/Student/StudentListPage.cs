using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Student
{
    public class StudentListPage
    {
        private static IWebDriver driver;

        public StudentListPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public StudentListPage NavigateTo()
        {
            driver.Navigate().GoToUrl("http://localhost:53412/Student");
            return this;
        }

        public bool HasTDElement(string message)
        {
            return driver.FindElements(By.TagName("td")).Any(t => t.Text == message);
        }

    }
}
