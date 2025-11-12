using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebAddressbookTests;

namespace SeleniumTests
{
    [TestFixture]
    public class CreateAddressTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void CreateNewAddress()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewAddress();
            AddressData address = new AddressData("Ruslan", "Ruslanov", "123 Main St, Anytown", "555-1234", "rus@test.ru", "20", "May", "1990");
            address.Middlename = "Ruslanovich";
            address.Nickname = "ruslan123";
            address.Title = "Mr.";
            address.Company = "Ruslan Inc.";
            FillAddressForm(address);
            Submit();
            HomePage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void HomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        private void Submit()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
        }

        private void FillAddressForm(AddressData address)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(address.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(address.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(address.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(address.Nickname);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(address.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(address.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(address.Address);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(address.HomePhone);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(address.Email);
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bday")).SendKeys(address.BurthdayData);
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.Name("bmonth")).SendKeys(address.BirthMonthData);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(address.BirthYearData);
        }

        private void AddNewAddress()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
