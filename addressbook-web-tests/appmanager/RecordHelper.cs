using OpenQA.Selenium;
using System;


namespace WebAddressbookTests
{
    public class RecordHelper : HelperBase
    {
        public RecordHelper(ApplicationManager manager) : base(manager)
        {
        }

        public RecordHelper SubmitRecordCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }

        public RecordHelper Modify(RecordData newData)
        {
            manager.Navigator.GoToHomePage();
            if (IsEmptyRecord())
            {
                return this;
            }
            SelectRecordToEdit();
            FillRecordForm(newData);
            SubmitRecordUpdate();
            return this;
        }

        public RecordHelper SubmitRecordUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public RecordHelper Remove()
        {
            manager.Navigator.GoToHomePage();
            if (IsEmptyRecord()) {
                return this;
            }
            SelectRecord();
            RemoveRecord();
            ReturnToHomePage();
            return this;
        }

        public bool IsEmptyRecord()
        {
            return !IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td"));
        }

        public void SelectRecordToEdit()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]")).Click();
        }

        private void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void RemoveRecord()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        private void SelectRecord()
        {
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td")))
            {
                return;
            }
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td")).Click();
        }

        public RecordHelper FillRecordForm(RecordData address)
        {
            Type(By.Name("firstname"), address.Firstname);
            Type(By.Name("middlename"), address.Middlename);
            Type(By.Name("lastname"), address.Lastname);
            Type(By.Name("nickname"), address.Nickname);
            Type(By.Name("title"), address.Title);
            Type(By.Name("company"), address.Company);
            Type(By.Name("address"), address.Address);
            Type(By.Name("home"), address.HomePhone);
            Type(By.Name("email"), address.Email);
            TypeList(By.Name("bday"), address.BurthdayData);
            TypeList(By.Name("bmonth"), address.BirthMonthData);
            TypeList(By.Name("byear"), address.BirthYearData);;
            return this;
        }

        public RecordHelper AddNewRecord()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        
    }
}
