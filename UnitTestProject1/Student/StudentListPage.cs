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

    }
}
