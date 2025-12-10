using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.Threading;

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
        protected RecordHelper addressHelper;
        
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        // Конструктор
        private ApplicationManager()
        {

            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            
            // Helpers
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
            addressHelper = new RecordHelper(this);
        }
        // Деструктор
        ~ApplicationManager()
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

        // Получение экземпляра класса ApplicationManager
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToStartPage();
                app.Value = newInstance;
            }
            return app.Value;
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

        public RecordHelper Record
                    {
            get
            {
                return addressHelper;
            }
        }
    }
}
