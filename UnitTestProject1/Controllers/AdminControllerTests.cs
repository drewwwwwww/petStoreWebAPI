using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject1.Controllers
{


    [TestClass]
    public class AdminControllerTests
    {
        public IWebDriver Driver;

        [SetUp]
        public void SetUp() 
        {
            Console.WriteLine("Setup");
            Driver = new ChromeDriver();
        }

        [Test]
        public void Register_User_Creates_New_User() 
        {
            Driver.Navigate().GoToUrl("http://monitoringmvcwebapp.azurewebsites.net/");

            Assert.IsTrue(Driver.FindElement(By.ClassName("registerPage")).Displayed);
        }
    }
}
