using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

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
        public void Register_Button_Routes_To_Correct_Page()
        {
            Driver.Navigate().GoToUrl("http://monitoringmvcwebapp.azurewebsites.net/");

            Assert.IsTrue(Driver.FindElement(By.Id("registerPage")).Displayed);
        }

        [Test]
        public void Login_Button_Routes_To_Correct_Page()
        {
            Driver.Navigate().GoToUrl("http://monitoringmvcwebapp.azurewebsites.net/");

            Assert.IsTrue(Driver.FindElement(By.Id("loginPage")).Displayed);
        }

        [Test]
        public void Register_Page_Creates_New_User()
        {
            Driver.Navigate().GoToUrl("http://monitoringmvcwebapp.azurewebsites.net/Identity/Account/Register");

            WebElement? emailForm = (WebElement?)(Driver.FindElement(By.Id("Input_Email")));

            emailForm?.SendKeys("SelniumTest@Test.com");

            WebElement? passwordForm = (WebElement?)(Driver.FindElement(By.Id("Input_Password")));

            passwordForm?.SendKeys("Password1!");

            WebElement? passwrodConfirmForm = (WebElement?)(Driver.FindElement(By.Id("Input_ConfirmPassword")));

            passwrodConfirmForm?.SendKeys("Password1!");

            WebElement? submitButton = (WebElement?)(Driver.FindElement(By.Id("registerSubmit")));

            submitButton.Click();

            WebElement? userNameInTopRight = (WebElement?)(Driver.FindElement(By.XPath("//a[@title='Manage']")));

            Assert.IsTrue(!userNameInTopRight.Text.Equals("SelniumTest@Test.com"));
        }
    }
}