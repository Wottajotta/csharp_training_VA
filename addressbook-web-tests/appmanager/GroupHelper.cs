using OpenQA.Selenium;
using System;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }


        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitNewGroup();
            FillGroup(group);
            SumbitGroupCreation();
            ReturnToGroupPage();
            return this;
        }
        public GroupHelper Remove(int n)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(n);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitNewGroup()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroup(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }
        public GroupHelper SumbitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        
    }
}
