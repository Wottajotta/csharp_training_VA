using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


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
            recordCache = null;
            return this;
        }


        public RecordHelper Modify(int v, RecordData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectRecordToEdit(v);
            FillRecordForm(newData);
            SubmitRecordUpdate();
            return this;
        }

        public RecordHelper SubmitRecordUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            recordCache = null;
            return this;
        }

        public RecordHelper Remove()
        {
            manager.Navigator.GoToHomePage();
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

        public void SelectRecordToPage(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[7]")).Click();
        }

        private void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void RemoveRecord()
        {
            driver.FindElement(By.Name("delete")).Click();
            recordCache = null;
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

        private List<RecordData> recordCache = null;

        public List<RecordData> GetRecordList()
        {
            if (recordCache == null)
            {
                recordCache = new List<RecordData>();
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

                    recordCache.Add(new RecordData(firstname, lastname));
                }
            }
            recordCache = recordCache
                .OrderBy(r => r.Lastname ?? string.Empty, StringComparer.OrdinalIgnoreCase)
                .ThenBy(r => r.Firstname, StringComparer.OrdinalIgnoreCase)
                .ToList();
            return new List<RecordData>(recordCache);
        }

        public RecordData GetRecordInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;

            string allEmail = cells[4].Text;
            string allphones = cells[5].Text;

            return new RecordData(firstName, lastName)
            {
                Address = address,
                AllPhones = allphones,
                AllEmails = allEmail

            };
        }

        public RecordData GetRecordInformationFromForm(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectRecordToEdit(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");

            return new RecordData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email

            };
        }

        public RecordData GetRecordInformationFromPage(int index)
        {
            manager.Navigator.GoToHomePage();
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string Text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(Text);
            return Int32.Parse(m.Value);
        }


    }
}
