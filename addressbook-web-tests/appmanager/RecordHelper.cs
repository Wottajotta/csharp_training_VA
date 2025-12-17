using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WebAddressbookTests
{
    public class RecordHelper : HelperBase
    {
        public RecordHelper(ApplicationManager manager) : base(manager)
        {
        }

        public RecordHelper Create(RecordData record)
        {
            AddNewRecord();
            FillRecordForm(record);
            SubmitRecordCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public RecordHelper SubmitRecordCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }

        public RecordHelper Modify(int v, RecordData newData)
        {
            manager.Navigator.GoToHomePage();
            if (IsEmptyRecord())
            {
                return this;
            }
            SelectRecordToEdit(v);
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

        public void SelectRecordToEdit(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ (index+2) +"]/td[8]")).Click();
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

        public List<RecordData> GetRecordList()
        {
            List<RecordData> records = new List<RecordData>();
            manager.Navigator.GoToHomePage();

            ICollection<IWebElement> rows = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[position()>1]"));
            foreach (IWebElement row in rows)
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));

                string firstname = "";
                string lastname = "";

                if (cells.Count > 2 && !string.IsNullOrWhiteSpace(cells[2].Text))
                {
                    firstname = cells[2].Text.Trim();
                    lastname = cells.Count > 1 ? cells[1].Text.Trim() : "";
                }
                else if (cells.Count > 1)
                {
                    var parts = cells[1].Text.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 1)
                    {
                        firstname = parts[0];
                        lastname = "";
                    }
                    else
                    {
                        firstname = parts[0];
                        lastname = string.Join(" ", parts.Skip(1));
                    }
                }

                records.Add(new RecordData(firstname, lastname));
            }

            records = records
                .OrderBy(r => r.Lastname ?? string.Empty, StringComparer.OrdinalIgnoreCase)
                .ThenBy(r => r.Firstname, StringComparer.OrdinalIgnoreCase)
                .ToList();
            return records;
        }
    }
}
