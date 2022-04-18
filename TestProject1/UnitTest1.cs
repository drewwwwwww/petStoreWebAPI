using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {

        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("http://monitoringmvcwebapp.azurewebsites.net/");

            Assert.IsTrue(Driver.FindElement(By.ClassName("registerPage")).Displayed);
        }
    }
}