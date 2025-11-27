using OpenQA.Selenium;


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
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
