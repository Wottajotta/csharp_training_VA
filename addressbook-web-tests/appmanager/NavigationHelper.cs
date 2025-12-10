using OpenQA.Selenium;
using OpenQA.Selenium.Internal;


namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {

        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void GoToStartPage()
        {
            driver.Navigate().GoToUrl(manager.BaseURL);
        }

        public void GoToGroupPage()
        {
            if(driver.Url == manager.BaseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            if (driver.Url == manager.BaseURL + "/addressbook")
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
