using OpenQA.Selenium;
using System.Text;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;


        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
    }
}