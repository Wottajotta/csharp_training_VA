using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;


        public ApplicationManager()
        {

            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            
            // Helpers
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
        }
        public IWebDriver Driver { 
            get {
                return driver;
            }
        }

        public string BaseURL { 
            get
            {
                return baseURL;
            }
                }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
