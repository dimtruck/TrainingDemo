using log4net;
using Moq;
using NUnit.Framework;
using StudentApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTestLibrary.Helpers
{
    [TestFixture]
    public class LoggingAttributeTest
    {
        private LoggingAttribute _loggingAttribute;
        private Mock<ActionExecutedContext> _actionExecutedContext
            = new Mock<ActionExecutedContext>();
        private Mock<ActionExecutingContext> _actionExecutingContext
            = new Mock<ActionExecutingContext>();
        private static readonly ILog log = 
            LogManager.GetLogger(typeof(StudentApplication.MvcApplication));


        [SetUp]
        public void SetUp()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));
            _loggingAttribute = new LoggingAttribute();
        }

        [TearDown]
        public void TearDown()
        {
            //clear log
            String path = "log-file.txt";
            Console.WriteLine(File.ReadAllText("log-file.txt"));
            //File.Delete(path);
        }

        [Test]
        public void ActionExecutedTest()
        {
            //act
            _loggingAttribute.OnActionExecuted(_actionExecutedContext.Object);
            Thread.Sleep(100);
            //assert log entry exists
            String lines = File.ReadAllText("log-file.txt");
            Console.WriteLine(lines);
            Assert.That(lines.Contains("INFO  we executed a request for"));

        }

        [Test]
        public void ActionExecutingTest()
        {
            //act
            _loggingAttribute.OnActionExecuting(_actionExecutingContext.Object);

            //assert log entry exists
            String lines = File.ReadAllText("log-file.txt");
            Assert.That(lines.Contains("INFO  we are executing a request for"));
        }        
    }
}
