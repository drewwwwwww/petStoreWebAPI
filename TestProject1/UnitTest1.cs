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
            Driver.Navigate().GoToUrl("https://localhost:5001/");

            Assert.IsTrue(Driver.FindElement(By.Id("registerPage")).Displayed);
        }

        [Test]
        public void Login_Button_Routes_To_Correct_Page()
        {
            Driver.Navigate().GoToUrl("https://localhost:5001/");

            Assert.IsTrue(Driver.FindElement(By.Id("loginPage")).Displayed);
        }

        [Test]
        public void User_Button_Routes_To_Correct_Page()
        {
            Driver.Navigate().GoToUrl("https://localhost:5001/");
            
            Assert.IsTrue(Driver.FindElement(By.XPath("/ html / body / div / main / div[2] / a[1]")).Displayed);

            var button = Driver.FindElement(By.XPath("/html/body/div/main/div[2]/a[1]"));

            button.Click();

            Assert.That(Driver.Url == "https://localhost:5001/Identity/Account/Login?ReturnUrl=%2FUser%2FIndex");
        }

        [Test]
        public void Admin_Button_Routes_To_Correct_Page()
        {
            Driver.Navigate().GoToUrl("https://localhost:5001/");

            Assert.IsTrue(Driver.FindElement(By.XPath("/html/body/div/main/div[2]/a[2]")).Displayed);

            var button = Driver.FindElement(By.XPath("/html/body/div/main/div[2]/a[2]"));

            button.Click();

            Assert.That(Driver.Url == "https://localhost:5001/Identity/Account/Login?ReturnUrl=%2FAdmin%2FIndex");
        }



        [Test]
        public void Register_Page_Creates_New_User()
        {
            Driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Register");

            WebElement? emailForm = (WebElement?)(Driver.FindElement(By.Id("Input_Email")));

            emailForm?.SendKeys("SelniumTest@Test.com");

            WebElement? passwordForm = (WebElement?)(Driver.FindElement(By.Id("Input_Password")));

            passwordForm?.SendKeys("Password1!");

            WebElement? passwordConfirmForm = (WebElement?)(Driver.FindElement(By.Id("Input_ConfirmPassword")));

            passwordConfirmForm?.SendKeys("Password1!");

            WebElement? submitButton = (WebElement?)(Driver.FindElement(By.Id("registerSubmit")));

            submitButton.Click();

            WebElement? userNameInTopRight = (WebElement?)(Driver.FindElement(By.XPath("//a[@title='Manage']")));

            Assert.IsTrue(!userNameInTopRight.Text.Equals("SeleniumTest@Test.com"));
        }

        [Test]
        public void Delete_User_Method()
        {
            //login as admin

            Driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login?ReturnUrl=%2FAdmin");

            WebElement? emailForm = (WebElement?)(Driver.FindElement(By.Id("Input_Email")));

            WebElement? passwordForm = (WebElement?)(Driver.FindElement(By.Id("Input_Password")));

            WebElement? submitButton = (WebElement?)(Driver.FindElement(By.Id("login-submit")));

            emailForm?.SendKeys("admin@admin.com");

            passwordForm?.SendKeys("Admin1!");

            submitButton.Click();

            //go to and delete selenium test user

            WebElement? maintainUsersButton = (WebElement?)Driver.FindElement(By.XPath("//a[text()='Maintain User Accounts']"));

            maintainUsersButton?.Click();

            WebElement? deleteButton = (WebElement?)Driver.FindElement(By.XPath("//td[contains(text(),'SelniumTest@Test.com')]/following-sibling::td/descendant::form/button[contains(text(),'Delete')]")); 

            deleteButton?.Click();

        }
    }
}